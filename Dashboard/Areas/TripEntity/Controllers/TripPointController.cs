using Contracts.Logger;
using Dashboard.Areas.TripEntity.Models;
using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.TripModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.TripEntity.Controllers
{
    [Area("TripEntity")]
    [Authorize(DashboardViewEnum.TripPoint, AccessLevelEnum.View)]
    public class TripPointController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public TripPointController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }
        
        public IActionResult Index(int id, int fk_Trip, bool ProfileLayOut = false)
        {

            TripPointFilter filter = new()
            {
                Id = id,
                Fk_Trip = fk_Trip
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData(id: 0);
            
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] TripPointFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

           TripPointParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<TripPointModel> data = await _unitOfWork.Trip.GetTripPointsPaged(parameters, otherLang);

            List<TripPointDto> resultDto = _mapper.Map<List<TripPointDto>>(data);

            DataTable<TripPointDto> dataTableManager = new();

            DataTableResult<TripPointDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Trip.GetTripPointsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            TripPointDto data = _mapper.Map<TripPointDto>(_unitOfWork.Trip.GetTripPointById(id, otherLang));

            return View(data);
        }

        [HttpPost]
        [Authorize(DashboardViewEnum.TripPoint, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEditWizard(int id,
            TripPointCreateOrEditModel model)
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
                TripPoint dataDB = new();
                
                if (id == 0)
                {
                    dataDB = _mapper.Map<TripPoint>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Trip.CreateTripPoint(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Trip.FindTripPointById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    dataDB.LastModifiedBy = auth.UserName;
                }

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            return BadRequest(new List<string>() { ViewData[ViewDataConstants.Error].ToString() });
        }

        [Authorize(DashboardViewEnum.TripPoint, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            TripPoint data = await _unitOfWork.Trip.FindTripPointById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.TripPoint, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Trip.DeleteTripPoint(id);
            await _unitOfWork.Save();

            return NoContent();
        }

        //helper method
        private void SetViewData(int id)
        {
            ViewData["id"] = id;
        }

    }
}
