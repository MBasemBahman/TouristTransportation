using Contracts.Logger;
using Dashboard.Areas.MainDataEntity.Models;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.MainDataEntity.Controllers
{
    [Area("MainDataEntity")]
    [Authorize(DashboardViewEnum.Area, AccessLevelEnum.View)]
    public class AreaController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public AreaController(ILoggerManager logger, IMapper mapper,
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

            AreaFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] AreaFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AreaParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<AreaModel> data = await _unitOfWork.MainData.GetAreasPaged(parameters, otherLang);

            List<AreaDto> resultDto = _mapper.Map<List<AreaDto>>(data);

            DataTable<AreaDto> dataTableManager = new();

            DataTableResult<AreaDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.MainData.GetAreasCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            AreaDto data = _mapper.Map<AreaDto>(_unitOfWork.MainData.GetAreaById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Area, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            AreaCreateOrEditModel model = new();

            if (id > 0)
            {
                Area dataDB = await _unitOfWork.MainData.FindAreaById(id, trackChanges: false);
                model = _mapper.Map<AreaCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.AreaLangs ??= new List<AreaLangModel>();

                    if (model.AreaLangs.All(a => a.Language != language))
                    {
                        model.AreaLangs.Add(new AreaLangModel
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
        [Authorize(DashboardViewEnum.Area, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, AreaCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                Area dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<Area>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.MainData.CreateArea(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.MainData.FindAreaById(id, trackChanges: true);

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

        [Authorize(DashboardViewEnum.Area, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            Area data = await _unitOfWork.MainData.FindAreaById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.Area, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.MainData.DeleteArea(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["id"] = id;
            ViewData["Country"] = _unitOfWork.MainData.GetCountriesLookUp(new CountryParameters(), otherLang);
        }

    }
}
