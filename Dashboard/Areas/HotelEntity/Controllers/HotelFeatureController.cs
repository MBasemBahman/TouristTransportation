using Contracts.Logger;
using Entities.CoreServicesModels.HotelModels;

namespace Dashboard.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.Hotel, AccessLevelEnum.View)]
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

        public async Task<ActionResult> CreateOrEditBulk(int id, List<int> hotelFeatures)
        {
            _unitOfWork.Hotel.UpdateHotelFeatures(id, hotelFeatures);

            await _unitOfWork.Save();
            
            return Ok(new HotelModel
            {
                Id = id
            });
        }
        
    }
}
