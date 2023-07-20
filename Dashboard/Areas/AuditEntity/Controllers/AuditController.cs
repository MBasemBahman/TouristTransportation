using Contracts.Logger;
using Dashboard.Areas.AuditEntity.Models;
using Entities.CoreServicesModels.AuditModels;
using Entities.RequestFeatures;

namespace Dashboard.Areas.AuditEntity.Controllers
{
    [Area("AuditEntity")]
    [Authorize(DashboardViewEnum.Audit, AccessLevelEnum.View)]
    public class AuditController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;
        private readonly ILocalizationManager _localization;


        public AuditController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment, ILocalizationManager localization)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
            _localization = localization;
        }

        public IActionResult Index(int id, bool ProfileLayOut = false)
        {

            AuditFilter filter = new();

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData();

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] AuditFilter dtParameters)
        {
            bool otherLang = (bool)Request.HttpContext.Items[ApiConstants.Language];

            AuditParameters parameters = new()
            {
                SearchColumns = "Id,TableName"
            };
            if (dtParameters.TableName == "0")
            {
                dtParameters.TableName = null;
            }
            _ = _mapper.Map(dtParameters, parameters);

            parameters.TableNames = Enum.GetValues(typeof(AuditTableNameEnum)).Cast<AuditTableNameEnum>()
                                                                          .Select(v => v.ToString()).ToList();
            PagedList<AuditModel> data = await _unitOfWork.Audit.GetAuditsPaged(parameters, otherLang);

            List<AuditDto> resultDto = _mapper.Map<List<AuditDto>>(data);

            DataTable<AuditDto> dataTableManager = new();

            DataTableResult<AuditDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Audit.GetAuditsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            bool otherLang = (bool)Request.HttpContext.Items[ApiConstants.Language];

            AuditDto data = _mapper.Map<AuditDto>(_unitOfWork.Audit
                                                           .GetAuditbyId(id, otherLang));

            return View(data);
        }


        //helper method
        private void SetViewData()
        {
            Dictionary<string, string> TableNames = new();
            foreach (AuditTableNameEnum value in Enum.GetValues(typeof(AuditTableNameEnum)))
            {
                TableNames.Add(value.ToString(), _localization.Get(value.ToString()));
            }
            ViewData["TableNames"] = TableNames;
        }

    }
}
