using Contracts.Logger;
using Dashboard.Areas.CarEntity.Models;
using Entities.CoreServicesModels.CarModels;
using Entities.DBModels.CarModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.CarEntity.Controllers
{
    [Area("CarEntity")]
    [Authorize(DashboardViewEnum.CarClass, AccessLevelEnum.View)]
    public class CarClassController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public CarClassController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }

        public IActionResult Index(int id, int fk_CarCategory, bool ProfileLayOut = false)
        {

            CarClassFilter filter = new()
            {
                Id = id,
                Fk_CarCategory = fk_CarCategory
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData(id: 0);
            
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] CarClassFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CarClassParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<CarClassModel> data = await _unitOfWork.Car.GetCarClassesPaged(parameters, otherLang);

            List<CarClassDto> resultDto = _mapper.Map<List<CarClassDto>>(data);

            DataTable<CarClassDto> dataTableManager = new();

            DataTableResult<CarClassDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Car.GetCarClassesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CarClassDto data = _mapper.Map<CarClassDto>(_unitOfWork.Car.GetCarClassById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.CarClass, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            CarClassCreateOrEditModel model = new();

            if (id > 0)
            {
                CarClass dataDB = await _unitOfWork.Car.FindCarClassById(id, trackChanges: false);
                model = _mapper.Map<CarClassCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.CarClassLangs ??= new List<CarClassLangModel>();

                    if (model.CarClassLangs.All(a => a.Language != language))
                    {
                        model.CarClassLangs.Add(new CarClassLangModel
                        {
                            Language = language
                        });
                    }
                }

                #endregion
            }

            SetViewData(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.CarClass, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, CarClassCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                CarClass dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<CarClass>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Car.CreateCarClass(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Car.FindCarClassById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    dataDB.LastModifiedBy = auth.UserName;
                }

                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }
            SetViewData(id);
            return View(model);
        }

        [Authorize(DashboardViewEnum.CarClass, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            CarClass data = await _unitOfWork.Car.FindCarClassById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.CarClass, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Car.DeleteCarClass(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["id"] = id;
            ViewData["CarCategory"] = _unitOfWork.Car.GetCarCategoriesLookUp(new CarCategoryParameters(), otherLang);
        }

    }
}
