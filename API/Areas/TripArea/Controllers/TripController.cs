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

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            if (auth.Fk_AccountType == (int)AccountTypeEnum.Client)
            {
                parameters.Fk_Client = auth.Fk_Account;
            }
            else if (auth.Fk_AccountType == (int)AccountTypeEnum.Driver)
            {
                parameters.Fk_Driver = auth.Fk_Account;
            }
            
            parameters.RateInPounds = auth.RateInPounds;

            PagedList<TripModel> trips = await _unitOfWork.Trip.GetTripsPaged(parameters, language);

            SetPagination(trips.MetaData, parameters);

            List<TripDto> tripsDto = _mapper.Map<List<TripDto>>(trips);

            return tripsDto;
        }

        [HttpGet]
        [Route(nameof(GetTrip))]
        public TripDto GetTrip(
          [FromQuery, BindRequired] int id)
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

            TripDto tripDto = _mapper.Map<TripDto>(trip);

            tripDto.TripPoints = _mapper.Map<List<TripPointDto>>
                (
                _unitOfWork.Trip.GetTripPoints(new TripPointParameters
                {
                    Fk_Trip = id,
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


        [HttpPost]
        [Route(nameof(CreateTrip))]
        public async Task<TripDto> CreateTrip([FromBody] TripCreateDto model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            Trip trip = _mapper.Map<Trip>(model);

            trip.Fk_Client = auth.Fk_Account;

            trip.Fk_TripState = (int)TripStateEnum.Pending;

            trip.CreatedBy = auth.Name;

            _unitOfWork.Trip.CreateTrip(trip);

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


            return tripDto;
        }

        [HttpPut]
        [Route(nameof(EditTrip))]
        public async Task<TripDto> EditTrip([FromQuery, BindRequired] int id, [FromBody] TripEditDto model)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            Trip trip = await _unitOfWork.Trip.FindTripById(id, trackChanges: true);

            if (trip.Fk_Client != auth.Fk_Account &&
                trip.Fk_Driver != auth.Fk_Account)
            {
                throw new Exception("Not Allowed");
            }

            _ = _mapper.Map(model, trip);

            trip.LastModifiedBy = auth.Name;

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

        [HttpDelete]
        [Route(nameof(CancelTrip))]
        public async Task<TripDto> CancelTrip([FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            Trip trip = await _unitOfWork.Trip.FindTripById(id, trackChanges: true);

            if (trip.Fk_Client != auth.Fk_Account &&
                trip.Fk_Driver != auth.Fk_Account)
            {
                throw new Exception("Not Allowed");
            }

            trip.LastModifiedBy = auth.Name;

            trip.Fk_TripState = (int)TripStateEnum.Canceled;

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
