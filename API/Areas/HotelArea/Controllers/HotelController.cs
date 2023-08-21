using API.Areas.HotelArea.Models;
using Entities.CoreServicesModels.HotelModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.HotelArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Hotel")]
    [ApiExplorerSettings(GroupName = "Hotel")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
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

            parameters.IncludeSelectedFeature = true;
            parameters.IsActive = true;
            
            PagedList<HotelModel> hotels = await _unitOfWork.Hotel.GetHotelsPaged(parameters, language);

            SetPagination(hotels.MetaData, parameters);

            List<HotelDto> hotelsDto = _mapper.Map<List<HotelDto>>(hotels);

            return hotelsDto;
        }

        [HttpGet]
        [Route(nameof(GetHotel))]
        public async Task<HotelDto> GetHotel(
          [FromQuery, BindRequired] int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            //For My Reaction
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelModel hotel = _unitOfWork.Hotel.GetHotelById(id, language);

            HotelDto hotelDto = _mapper.Map<HotelDto>(hotel);

            hotelDto = await SetAttachments(hotelDto);

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
