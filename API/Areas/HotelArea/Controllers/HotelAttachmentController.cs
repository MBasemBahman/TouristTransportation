using API.Areas.HotelArea.Models;
using Entities.CoreServicesModels.HotelModels;

namespace API.Areas.HotelArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Hotel")]
    [ApiExplorerSettings(GroupName = "Hotel")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class HotelAttachmentController : ExtendControllerBase
    {
        public HotelAttachmentController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        { }

        [HttpGet]
        [Route(nameof(GetHotelAttachments))]
        public async Task<IEnumerable<HotelAttachmentDto>> GetHotelAttachments(
        [FromQuery] HotelAttachmentParameters parameters)
        {
            if (parameters.Fk_Hotel == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            PagedList<HotelAttachmentModel> attachments = await _unitOfWork.Hotel.GetHotelAttachmentsPaged(parameters, language);

            SetPagination(attachments.MetaData, parameters);

            IEnumerable<HotelAttachmentDto> attachmentsDto = _mapper.Map<IEnumerable<HotelAttachmentDto>>(attachments);

            return attachmentsDto;
        }
    }
}
