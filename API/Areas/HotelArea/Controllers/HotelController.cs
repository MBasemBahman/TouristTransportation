using API.Areas.HotelArea.Models;
using Entities.CoreServicesModels.HotelModels;

namespace API.Areas.HotelArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Hotel")]
    [ApiExplorerSettings(GroupName = "Hotel")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class HotelController : ExtendControllerBase
    {
        public HotelController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {
            
        }

        [HttpGet]
        [Route(nameof(GetHotels))]
        public async Task<IEnumerable<HotelDto>> GetHotels([FromQuery] HotelParameters parameters)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            if (auth.Fk_Account == 0)
            {
                throw new Exception("Not Allowed");
            }
            
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<HotelModel> hotels = await _unitOfWork.Hotel.GetHotelsPaged(parameters, language);

            SetPagination(hotels.MetaData, parameters);

            List<HotelDto> hotelsDto = _mapper.Map<List<HotelDto>>(hotels);

            hotelsDto.ForEach(hotel =>
            {
                hotel = SetAttachments(hotel).Result;
                if (hotel.OldHotel != null && hotel.OldHotel.AttachmentsCount > 0)
                {
                    hotel.OldHotel = SetAttachments(hotel.OldHotel).Result;
                }
            });

            return hotelsDto;
        }

        [HttpGet]
        [Route(nameof(GetHotel))]
        public async Task<HotelDto> GetHotel(
          [FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            //For My Reaction
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelModel hotel = _unitOfWork.Hotel.GetHotelById(id, language);

            HotelDto hotelDto = _mapper.Map<HotelDto>(hotel);

            hotelDto = await SetAttachments(hotelDto);

            if (hotelDto.OldHotel is { AttachmentsCount: > 0 })
            {
                hotelDto.OldHotel = SetAttachments(hotelDto.OldHotel).Result;
            }

            return hotelDto;
        }

        // Helper Methods
        private async Task<HotelDto> SetAttachments(HotelDto post)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            
            if (post.AttachmentsCount > 0 && post.Id > 0)
            {
                post.Attachments = _mapper.Map<IEnumerable<HotelAttachmentDto>>(
                    await _unitOfWork.Hotel.GetHotelAttachmentsPaged(new HotelAttachmentParameters
                    {
                        Fk_Hotel = post.Id,
                        PageNumber = 1,
                        PageSize = 5,
                    }, language));
            }

            return post;
        }
    }
}
