using Contracts.Logger;
using Dashboard.Areas.HotelEntity.Models;
using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.HotelFeatureCategory, AccessLevelEnum.View)]
    public class HotelFeatureCategoryController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public HotelFeatureCategoryController(ILoggerManager logger, IMapper mapper,
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

            HotelFeatureCategoryFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelFeatureCategoryFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelFeatureCategoryParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<HotelFeatureCategoryModel> data = await _unitOfWork.Hotel.GetHotelFeatureCategoriesPaged(parameters, otherLang);

            List<HotelFeatureCategoryDto> resultDto = _mapper.Map<List<HotelFeatureCategoryDto>>(data);

            DataTable<HotelFeatureCategoryDto> dataTableManager = new();

            DataTableResult<HotelFeatureCategoryDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Hotel.GetHotelFeatureCategoriesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            HotelFeatureCategoryDto data = _mapper.Map<HotelFeatureCategoryDto>(_unitOfWork.Hotel.GetHotelFeatureCategoryById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.HotelFeatureCategory, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            HotelFeatureCategoryCreateOrEditModel model = new();

            if (id > 0)
            {
                HotelFeatureCategory dataDB = await _unitOfWork.Hotel.FindHotelFeatureCategoryById(id, trackChanges: false);
                model = _mapper.Map<HotelFeatureCategoryCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.HotelFeatureCategoryLangs ??= new List<HotelFeatureCategoryLangModel>();

                    if (model.HotelFeatureCategoryLangs.All(a => a.Language != language))
                    {
                        model.HotelFeatureCategoryLangs.Add(new HotelFeatureCategoryLangModel
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
        [Authorize(DashboardViewEnum.HotelFeatureCategory, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, HotelFeatureCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                HotelFeatureCategory dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<HotelFeatureCategory>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Hotel.CreateHotelFeatureCategory(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Hotel.FindHotelFeatureCategoryById(id, trackChanges: true);

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

        [Authorize(DashboardViewEnum.HotelFeatureCategory, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            HotelFeatureCategory data = await _unitOfWork.Hotel.FindHotelFeatureCategoryById(id, trackChanges: false);

            return View(data != null &&
                !_unitOfWork.Hotel.GetHotelFeatures(new HotelFeatureParameters
                {
                    Fk_HotelFeatureCategory = id
                },language:null).Any());
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.HotelFeatureCategory, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Hotel.DeleteHotelFeatureCategory(id);
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
