using API.Areas.TripArea.Models;
using Entities.CoreServicesModels.TripModels;
namespace API.Areas.TripArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Trip")]
    [ApiExplorerSettings(GroupName = "Trip")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class TripMainDataController : ExtendControllerBase
    {
        public TripMainDataController(
      ILoggerManager logger,
      IMapper mapper,
      UnitOfWork unitOfWork,
      LinkGenerator linkGenerator,
      IWebHostEnvironment environment,
      IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }


        [HttpGet]
        [Route(nameof(GetTripStates))]
        public async Task<IEnumerable<TripStateDto>> GetTripStates([FromQuery] TripStateParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<TripStateModel> tripStates = await _unitOfWork.Trip.GetTripStatesPaged(parameters, language);

            SetPagination(tripStates.MetaData, parameters);

            List<TripStateDto> tripStatesDto = _mapper.Map<List<TripStateDto>>(tripStates);

            return tripStatesDto;
        }
    }
}
