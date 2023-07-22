using Contracts.Logger;
using Dashboard.Areas.HotelEntity.Models;
using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.HotelFeature, AccessLevelEnum.View)]
    public class HotelFeatureController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public HotelFeatureController(ILoggerManager logger, IMapper mapper,
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

            HotelFeatureFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelFeatureFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelFeatureParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<HotelFeatureModel> data = await _unitOfWork.Hotel.GetHotelFeaturesPaged(parameters, otherLang);

            List<HotelFeatureDto> resultDto = _mapper.Map<List<HotelFeatureDto>>(data);

            DataTable<HotelFeatureDto> dataTableManager = new();

            DataTableResult<HotelFeatureDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Hotel.GetHotelFeaturesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            HotelFeatureDto data = _mapper.Map<HotelFeatureDto>(_unitOfWork.Hotel.GetHotelFeatureById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.HotelFeature, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            HotelFeatureCreateOrEditModel model = new();

            if (id > 0)
            {
                HotelFeature dataDB = await _unitOfWork.Hotel.FindHotelFeatureById(id, trackChanges: false);
                model = _mapper.Map<HotelFeatureCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.HotelFeatureLangs ??= new List<HotelFeatureLangModel>();

                    if (model.HotelFeatureLangs.All(a => a.Language != language))
                    {
                        model.HotelFeatureLangs.Add(new HotelFeatureLangModel
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
        [Authorize(DashboardViewEnum.HotelFeature, AccessLevelEnum.CreateOrEdit)]
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
                HotelFeature dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<HotelFeature>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Hotel.CreateHotelFeature(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Hotel.FindHotelFeatureById(id, trackChanges: true);

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

        [Authorize(DashboardViewEnum.HotelFeature, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            HotelFeature data = await _unitOfWork.Hotel.FindHotelFeatureById(id, trackChanges: false);

            return View(data != null &&
                !_unitOfWork.Hotel.GetHotelSelectedFeatures(new HotelSelectedFeaturesParameters
                {
                    Fk_HotelFeature = id
                }, language: null).Any()) ;
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.HotelFeature, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Hotel.DeleteHotelFeature(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["id"] = id;
            ViewData["HotelFeatureCategory"] = _unitOfWork.Hotel.GetHotelFeatureCategorysLookUp (new HotelFeatureCategoryParameters(), otherLang);
        }

    }
}
