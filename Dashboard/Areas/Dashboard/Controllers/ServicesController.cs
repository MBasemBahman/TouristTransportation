using Entities.CoreServicesModels.MainDataModels;

namespace Dashboard.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServicesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

        public ServicesController(IMapper mapper, UnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public ActionResult<List<AreaModel>> GetAreasByFilters(AreaParameters parameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            return _unitOfWork.MainData.GetAreas(parameters, otherLang).ToList();
        }
    }
}
