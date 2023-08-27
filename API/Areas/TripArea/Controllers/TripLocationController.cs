using API.Areas.TripArea.Models;
using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.TripModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.TripArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Trip")]
    [ApiExplorerSettings(GroupName = "Trip")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class TripLocationController : ExtendControllerBase
    {
        public TripLocationController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetTripLocations))]
        public async Task<IEnumerable<TripLocationDto>> GetTripLocations([FromQuery] TripLocationParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<TripLocationModel> tripLocations = await _unitOfWork.Trip.GetTripLocationsPaged(parameters, language);

            SetPagination(tripLocations.MetaData, parameters);

            List<TripLocationDto> tripLocationsDto = _mapper.Map<List<TripLocationDto>>(tripLocations);

            return tripLocationsDto;
        }

        [HttpPost]
        [Route(nameof(CreateTripLocation))]
        public async Task<TripLocationDto> CreateTripLocation([FromBody] TripLocationCreateDto model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            if (model.Fk_Trip == 0)
            {
                throw new Exception("Bad Request!");
            }

            Trip trip = await _unitOfWork.Trip.FindTripById(model.Fk_Trip, trackChanges: false);

            if (trip.Fk_Client != auth.Fk_Account)
            {
                throw new Exception("Not Allowed");
            }
            TripLocation tripLocation = _mapper.Map<TripLocation>(model);


            _unitOfWork.Trip.CreateTripLocation(tripLocation);

            await _unitOfWork.Save();

            TripLocationModel tripLocationModel = _unitOfWork.Trip.GetTripLocationById(tripLocation.Id, language);

            TripLocationDto tripLocationDto = _mapper.Map<TripLocationDto>(tripLocationModel);

            return tripLocationDto;
        }

     
    }
}
