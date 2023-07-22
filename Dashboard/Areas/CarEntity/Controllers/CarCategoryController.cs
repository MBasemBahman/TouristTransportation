using Contracts.Logger;
using Dashboard.Areas.CarEntity.Models;
using Entities.CoreServicesModels.CarModels;
using Entities.DBModels.CarModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.CarEntity.Controllers
{
    [Area("CarEntity")]
    [Authorize(DashboardViewEnum.CarCategory, AccessLevelEnum.View)]
    public class CarCategoryController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public CarCategoryController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }

        public IActionResult Index(int id, bool ProfileLayOut = false)
        {

            CarCategoryFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] CarCategoryFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CarCategoryParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<CarCategoryModel> data = await _unitOfWork.Car.GetCarCategoriesPaged(parameters, otherLang);

            List<CarCategoryDto> resultDto = _mapper.Map<List<CarCategoryDto>>(data);

            DataTable<CarCategoryDto> dataTableManager = new();

            DataTableResult<CarCategoryDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Car.GetCarCategoriesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            CarCategoryDto data = _mapper.Map<CarCategoryDto>(_unitOfWork.Car.GetCarCategoryById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.CarCategory, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            CarCategoryCreateOrEditModel model = new();

            if (id > 0)
            {
                CarCategory dataDB = await _unitOfWork.Car.FindCarCategoryById(id, trackChanges: false);
                model = _mapper.Map<CarCategoryCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.CarCategoryLangs ??= new List<CarCategoryLangModel>();

                    if (model.CarCategoryLangs.All(a => a.Language != language))
                    {
                        model.CarCategoryLangs.Add(new CarCategoryLangModel
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
        [Authorize(DashboardViewEnum.CarCategory, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, CarCategoryCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                CarCategory dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<CarCategory>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Car.CreateCarCategory(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Car.FindCarCategoryById(id, trackChanges: true);

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

        [Authorize(DashboardViewEnum.CarCategory, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            CarCategory data = await _unitOfWork.Car.FindCarCategoryById(id, trackChanges: false);

            return View(data != null && 
                !_unitOfWork.Car.GetCarClasses(new CarClassParameters
                {
                    Fk_CarCategory = id
                },language:null).Any());
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.CarCategory, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Car.DeleteCarCategory(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["id"] = id;
        }

    }
}
