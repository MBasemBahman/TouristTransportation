using Contracts.Logger;
using Dashboard.Areas.CompanyTripEntity.Models;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.CompanyTripEntity.Controllers
{
    [Area("CompanyTripEntity")]
    [Authorize(DashboardViewEnum.CompanyTripState, AccessLevelEnum.View)]
    public class CompanyTripStateController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public CompanyTripStateController(ILoggerManager logger, IMapper mapper,
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

            CompanyTripStateFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] CompanyTripStateFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripStateParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<CompanyTripStateModel> data = await _unitOfWork.CompanyTrip.GetCompanyTripStatesPaged(parameters, otherLang);

            List<CompanyTripStateDto> resultDto = _mapper.Map<List<CompanyTripStateDto>>(data);

            DataTable<CompanyTripStateDto> dataTableManager = new();

            DataTableResult<CompanyTripStateDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.CompanyTrip.GetCompanyTripStatesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripStateDto data = _mapper.Map<CompanyTripStateDto>(_unitOfWork.CompanyTrip.GetCompanyTripStateById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.CompanyTripState, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            CompanyTripStateCreateOrEditModel model = new();

            if (id > 0)
            {
                CompanyTripState dataDB = await _unitOfWork.CompanyTrip.FindCompanyTripStateById(id, trackChanges: false);
                model = _mapper.Map<CompanyTripStateCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.CompanyTripStateLangs ??= new List<CompanyTripStateLangModel>();
                
                    if (model.CompanyTripStateLangs.All(a => a.Language != language))
                    {
                        model.CompanyTripStateLangs.Add(new CompanyTripStateLangModel
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
        [Authorize(DashboardViewEnum.CompanyTripState, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, CompanyTripStateCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                CompanyTripState dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<CompanyTripState>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.CompanyTrip.CreateCompanyTripState(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.CompanyTrip.FindCompanyTripStateById(id, trackChanges: true);

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

        [Authorize(DashboardViewEnum.CompanyTripState, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            CompanyTripState data = await _unitOfWork.CompanyTrip.FindCompanyTripStateById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.CompanyTripState, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.CompanyTrip.DeleteCompanyTripState(id);
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
