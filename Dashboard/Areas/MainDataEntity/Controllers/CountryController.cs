using Contracts.Logger;
using Dashboard.Areas.MainDataEntity.Models;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.MainDataEntity.Controllers
{
    [Area("MainDataEntity")]
    [Authorize(DashboardViewEnum.Country, AccessLevelEnum.View)]
    public class CountryController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public CountryController(ILoggerManager logger, IMapper mapper,
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

            CountryFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] CountryFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CountryParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<CountryModel> data = await _unitOfWork.MainData.GetCountriesPaged(parameters, otherLang);

            List<CountryDto> resultDto = _mapper.Map<List<CountryDto>>(data);

            DataTable<CountryDto> dataTableManager = new();

            DataTableResult<CountryDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.MainData.GetCountriesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CountryDto data = _mapper.Map<CountryDto>(_unitOfWork.MainData.GetCountryById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Country, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            CountryCreateOrEditModel model = new();

            if (id > 0)
            {
                Country dataDB = await _unitOfWork.MainData.FindCountryById(id, trackChanges: false);
                model = _mapper.Map<CountryCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.CountryLangs ??= new List<CountryLangModel>();

                    if (model.CountryLangs.All(a => a.Language != language))
                    {
                        model.CountryLangs.Add(new CountryLangModel
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
        [Authorize(DashboardViewEnum.Country, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, CountryCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                Country dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<Country>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.MainData.CreateCountry(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.MainData.FindCountryById(id, trackChanges: true);

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

        [Authorize(DashboardViewEnum.Country, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            Country data = await _unitOfWork.MainData.FindCountryById(id, trackChanges: false);

            return View(data != null &&
                !_unitOfWork.MainData.GetAreas(new AreaParameters
                {
                    Fk_Country = id
                },language:null).Any()) ;
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.Country, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.MainData.DeleteCountry(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            ViewData["id"] = id;
        }

    }
}
