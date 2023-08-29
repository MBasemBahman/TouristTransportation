using Contracts.Logger;
using Dashboard.Areas.TripEntity.Models;
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.TripModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.TripModels;
using Entities.DBModels.MainDataModels;
using Entities.RequestFeatures;

namespace Dashboard.Areas.TripEntity.Controllers
{
    [Area("TripEntity")]
    [Authorize(DashboardViewEnum.Trip, AccessLevelEnum.View)]
    public class TripController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public TripController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }

        public IActionResult Index(int id, int fk_Account, int returnItem = (int)TripReturnItems.Index ,bool ProfileLayOut = false)
        {
            TripFilter filter = new()
            {
                Id = id,
                Fk_Account = fk_Account
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData(id: 0, returnItem);
            
            return View(filter);
        }
        
        public IActionResult Profile(int id, int returnItem = (int)TripProfileItems.Details)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
        
            TripDto data = _mapper.Map<TripDto>(_unitOfWork.Trip
                .GetTripById(id, otherLang));
        
            ViewData["otherLang"] = otherLang;
        
            ViewData["returnItem"] = returnItem;
            
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] TripFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            TripParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<TripModel> data = await _unitOfWork.Trip.GetTripsPaged(parameters, otherLang);

            List<TripDto> resultDto = _mapper.Map<List<TripDto>>(data);

            DataTable<TripDto> dataTableManager = new();

            DataTableResult<TripDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Trip.GetTripsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            TripDto data = _mapper.Map<TripDto>(_unitOfWork.Trip.GetTripById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Trip, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0, 
            int fk_Account = 0, 
            int returnItem = (int)TripReturnItems.Index)
        {
            TripCreateOrEditModel model = new();

            if (id > 0)
            {
                Trip dataDB = await _unitOfWork.Trip.FindTripById(id, trackChanges: false);
                model = _mapper.Map<TripCreateOrEditModel>(dataDB);
            }

            SetViewData(id, returnItem, model.Fk_Supplier);
            ViewData["fk_Account"] = fk_Account;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.Trip, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEditWizard(int id, TripCreateOrEditModel model, int tripReturnItems = (int)TripReturnItems.Index)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return BadRequest(errorMessages);
            }
            try
            {
                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                Trip dataDB = new();
                
                if (id == 0)
                {
                    dataDB = _mapper.Map<Trip>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Trip.CreateTrip(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Trip.FindTripById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    dataDB.LastModifiedBy = auth.UserName;
                }
                
                await _unitOfWork.Save();

                return Ok(new TripModel
                {
                    Id = dataDB.Id
                });
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            return BadRequest(new List<string> { ViewData[ViewDataConstants.Error].ToString() });
        }

        [Authorize(DashboardViewEnum.Trip, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            Trip data = await _unitOfWork.Trip.FindTripById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.Trip, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Trip.DeleteTrip(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id , int? returnItem = (int)TripReturnItems.Index, int? fk_Supplier = 0)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            ViewData["id"] = id;
            ViewData["returnItem"] = returnItem;
            ViewData["Suppliers"] = _unitOfWork.MainData.GetSuppliersLookUp(new SupplierParameters(), language);
            ViewData["CarClasses"] = _unitOfWork.Car.GetCarClassesLookUp(new CarClassParameters(), language);
            ViewData["TripStates"] = _unitOfWork.Trip.GetTripStatesLookUp(new TripStateParameters(), language);
            ViewData["Drivers"] = _unitOfWork.Account.GetAccountsLookUp(new AccountParameters
            {
                Fk_AccountType = (int)AccountTypeEnum.Driver,
                Fk_Supplier = fk_Supplier ?? 0
            }, language);
        }

    }
}
