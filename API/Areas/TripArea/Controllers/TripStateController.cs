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
    public class TripStateController : ExtendControllerBase
    {
        public TripStateController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetCurrentTripState))]
        public TripCurrentStateDto GetCurrentTripState([FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
            
            TripModel trip = _unitOfWork.Trip.GetTrips(new TripParameters
            {
                Id = id,
                RateInPounds = auth.RateInPounds
            }, language).FirstOrDefault();
            
            return new TripCurrentStateDto
            {
                Fk_CurrentTripState = trip.Fk_TripState,
                Fk_NextTripStates = _unitOfWork.Trip.GetNextTripStates(trip.Fk_TripState, auth)
            };
        }
    
        [HttpPut]
        [Route(nameof(EditTripState))]
        public async Task<TripDto> EditTripState([FromQuery, BindRequired] int id, [FromBody] int fk_TripState)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            Trip trip = await _unitOfWork.Trip.FindTripById(id, trackChanges: true);

            if (auth.Fk_AccountType == (int)AccountTypeEnum.Seller || trip.Fk_Driver != auth.Fk_Account)
            {
                throw new Exception("Access Denied!");
            }

            _unitOfWork.Trip.ChangeTripState(trip, fk_TripState, auth);

            await _unitOfWork.Save();

            _unitOfWork.Trip.UpdateTripHistory(trip, notes: null);

            await _unitOfWork.Save();

            TripModel tripModel = _unitOfWork.Trip.GetTrips(new TripParameters
            {
                Id = trip.Id,
                RateInPounds = auth.RateInPounds
            }, language).FirstOrDefault();

            TripDto tripDto = _mapper.Map<TripDto>(tripModel);

            tripDto.TripPoints = _mapper.Map<List<TripPointDto>>
                (
                _unitOfWork.Trip.GetTripPoints(new TripPointParameters
                {
                    Fk_Trip = trip.Id,
                    RateInPounds = auth.RateInPounds
                }, language).ToList()
                );
            tripDto.TripLocations = _mapper.Map<List<TripLocationDto>>
            (
            _unitOfWork.Trip.GetTripLocations(new TripLocationParameters
            {
                Fk_Trip = id
            }, language).ToList()
            );

            tripDto.TripHistories = _mapper.Map<List<TripHistoryDto>>
              (
              _unitOfWork.Trip.GetTripHistories(new TripHistoryParameters
              {
                  Fk_Trip = id
              }, language).ToList()
              );


            return tripDto;
        }

    }
}
