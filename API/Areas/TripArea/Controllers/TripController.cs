using API.Areas.TripArea.Models;
using Entities.CoreServicesModels.TripModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.TripArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Trip")]
    [ApiExplorerSettings(GroupName = "Trip")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class TripController : ExtendControllerBase
    {
        public TripController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetTrips))]
        public async Task<IEnumerable<TripDto>> GetTrips([FromQuery] TripParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            PagedList<TripModel> companyTrips = await _unitOfWork.Trip.GetTripsPaged(parameters, language);

            SetPagination(companyTrips.MetaData, parameters);

            List<TripDto> companyTripsDto = _mapper.Map<List<TripDto>>(companyTrips);

            return companyTripsDto;
        }

        [HttpGet]
        [Route(nameof(GetTrip))]
        public async Task<TripDto> GetTrip(
          [FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }
            
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            TripModel companyTrip = _unitOfWork.Trip.GetTripById(id, language);

            TripDto companyTripDto = _mapper.Map<TripDto>(companyTrip);
            
            return companyTripDto;
        }
    }
}
