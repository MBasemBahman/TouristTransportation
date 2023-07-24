using Contracts.Logger;
using Dashboard.Areas.TripEntity.Models;
using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.TripModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.TripEntity.Controllers
{
    [Area("TripEntity")]
    [Authorize(DashboardViewEnum.TripState, AccessLevelEnum.View)]
    public class TripStateController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public TripStateController(ILoggerManager logger, IMapper mapper,
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

            TripStateFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] TripStateFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

           TripStateParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<TripStateModel> data = await _unitOfWork.Trip.GetTripStatesPaged(parameters, otherLang);

            List<TripStateDto> resultDto = _mapper.Map<List<TripStateDto>>(data);

            DataTable<TripStateDto> dataTableManager = new();

            DataTableResult<TripStateDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Trip.GetTripStatesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            TripStateDto data = _mapper.Map<TripStateDto>(_unitOfWork.Trip.GetTripStateById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.TripState, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            TripStateCreateOrEditModel model = new();

            if (id > 0)
            {
                TripState dataDB = await _unitOfWork.Trip.FindTripStateById(id, trackChanges: false);
                model = _mapper.Map<TripStateCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.TripStateLangs ??= new List<TripStateLangModel>();

                    if (model.TripStateLangs.All(a => a.Language != language))
                    {
                        model.TripStateLangs.Add(new TripStateLangModel
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
        [Authorize(DashboardViewEnum.TripState, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, TripStateCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                TripState dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<TripState>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Trip.CreateTripState(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Trip.FindTripStateById(id, trackChanges: true);

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

        [Authorize(DashboardViewEnum.TripState, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            TripState data = await _unitOfWork.Trip.FindTripStateById(id, trackChanges: false);

            return View(data != null && 
                !_unitOfWork.Trip.GetTrips(new TripParameters
                {
                    Fk_TripState = id
                },language:null).Any());
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.TripState, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Trip.DeleteTripState(id);
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
