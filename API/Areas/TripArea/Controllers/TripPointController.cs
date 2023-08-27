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
    public class TripPointController : ExtendControllerBase
    {
        public TripPointController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetTripPoints))]
        public async Task<IEnumerable<TripPointDto>> GetTripPoints([FromQuery] TripPointParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<TripPointModel> tripPoints = await _unitOfWork.Trip.GetTripPointsPaged(parameters, language);

            SetPagination(tripPoints.MetaData, parameters);

            List<TripPointDto> tripPointsDto = _mapper.Map<List<TripPointDto>>(tripPoints);

            return tripPointsDto;
        }

        [HttpGet]
        [Route(nameof(GetTripPoint))]
        public TripPointDto GetTripPoint(
          [FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            TripPointModel tripPoint = _unitOfWork.Trip.GetTripPointById(id, language);

            TripPointDto tripPointDto = _mapper.Map<TripPointDto>(tripPoint);


            return tripPointDto;
        }


        [HttpPost]
        [Route(nameof(CreateTripPoint))]
        public async Task<TripPointDto> CreateTripPoint([FromBody] TripPointCreateDto model)
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
            TripPoint tripPoint = _mapper.Map<TripPoint>(model);


            _unitOfWork.Trip.CreateTripPoint(tripPoint);

            await _unitOfWork.Save();

            TripPointModel tripPointModel = _unitOfWork.Trip.GetTripPointById(tripPoint.Id, language);

            TripPointDto tripPointDto = _mapper.Map<TripPointDto>(tripPointModel);

            return tripPointDto;
        }

        [HttpPut]
        [Route(nameof(EditTripPoint))]
        public async Task<TripPointDto> EditTripPoint([FromQuery, BindRequired] int id, [FromBody] TripPointEditDto model)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            TripPoint tripPoint = await _unitOfWork.Trip.FindTripPointById(id, trackChanges: true);

            Trip trip = await _unitOfWork.Trip.FindTripById(tripPoint.Fk_Trip, trackChanges: false);

            if (trip.Fk_Client != auth.Fk_Account)
            {
                throw new Exception("Not Allowed");
            }
            _ = _mapper.Map(model, tripPoint);

            await _unitOfWork.Save();


            TripPointModel tripPointModel = _unitOfWork.Trip.GetTripPointById(tripPoint.Id, language);

            TripPointDto tripPointDto = _mapper.Map<TripPointDto>(tripPointModel);

            return tripPointDto;
        }

        [HttpDelete]
        [Route(nameof(RemoveTripPoint))]
        public async Task<bool> RemoveTripPoint([FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            TripPoint tripPoint = await _unitOfWork.Trip.FindTripPointById(id, trackChanges: false);

            Trip trip = await _unitOfWork.Trip.FindTripById(tripPoint.Fk_Trip, trackChanges: false);

            if (trip.Fk_Client != auth.Fk_Account)
            {
                throw new Exception("Not Allowed");
            }
            await _unitOfWork.Trip.DeleteTripPoint(id);

            await _unitOfWork.Save();

            return true;
        }

    }
}
