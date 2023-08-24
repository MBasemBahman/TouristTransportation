using Contracts.Logger;
using Dashboard.Areas.CompanyTripEntity.Models;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.CompanyTripEntity.Controllers
{
    [Area("CompanyTripEntity")]
    [Authorize(DashboardViewEnum.CompanyTripBookingState, AccessLevelEnum.View)]
    public class CompanyTripBookingStateController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public CompanyTripBookingStateController(ILoggerManager logger, IMapper mapper,
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

            CompanyTripBookingStateFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] CompanyTripBookingStateFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripBookingStateParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<CompanyTripBookingStateModel> data = await _unitOfWork.CompanyTrip.GetCompanyTripBookingStatesPaged(parameters, otherLang);

            List<CompanyTripBookingStateDto> resultDto = _mapper.Map<List<CompanyTripBookingStateDto>>(data);

            DataTable<CompanyTripBookingStateDto> dataTableManager = new();

            DataTableResult<CompanyTripBookingStateDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.CompanyTrip.GetCompanyTripBookingStatesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripBookingStateDto data = _mapper.Map<CompanyTripBookingStateDto>(_unitOfWork.CompanyTrip.GetCompanyTripBookingStateById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.CompanyTripBookingState, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            CompanyTripBookingStateCreateOrEditModel model = new();

            if (id > 0)
            {
                CompanyTripBookingState dataDB = await _unitOfWork.CompanyTrip.FindCompanyTripBookingStateById(id, trackChanges: false);
                model = _mapper.Map<CompanyTripBookingStateCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.CompanyTripBookingStateLangs ??= new List<CompanyTripBookingStateLangModel>();
                
                    if (model.CompanyTripBookingStateLangs.All(a => a.Language != language))
                    {
                        model.CompanyTripBookingStateLangs.Add(new CompanyTripBookingStateLangModel
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
        [Authorize(DashboardViewEnum.CompanyTripBookingState, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, CompanyTripBookingStateCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                CompanyTripBookingState dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<CompanyTripBookingState>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.CompanyTrip.CreateCompanyTripBookingState(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.CompanyTrip.FindCompanyTripBookingStateById(id, trackChanges: true);

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

        [Authorize(DashboardViewEnum.CompanyTripBookingState, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            CompanyTripBookingState data = await _unitOfWork.CompanyTrip.FindCompanyTripBookingStateById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.CompanyTripBookingState, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.CompanyTrip.DeleteCompanyTripBookingState(id);
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
