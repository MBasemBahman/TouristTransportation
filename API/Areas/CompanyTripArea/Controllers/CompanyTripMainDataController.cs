using API.Areas.CompanyTripArea.Models;
using Entities.CoreServicesModels.CompanyTripModels;

namespace API.Areas.CompanyTripArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("CompanyTrip")]
    [ApiExplorerSettings(GroupName = "CompanyTrip")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class CompanyTripMainDataController : ExtendControllerBase
    {
        public CompanyTripMainDataController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetCompanyTripStates))]
        public async Task<IEnumerable<CompanyTripStateDto>> GetCompanyTripStates([FromQuery] CompanyTripStateParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<CompanyTripStateModel> rows = await _unitOfWork.CompanyTrip.GetCompanyTripStatesPaged(parameters, language);

            SetPagination(rows.MetaData, parameters);

            List<CompanyTripStateDto> rowsDto = _mapper.Map<List<CompanyTripStateDto>>(rows);

            return rowsDto;
        }

        [HttpGet]
        [Route(nameof(GetCompanyTripBookingStates))]
        public async Task<IEnumerable<CompanyTripBookingStateDto>> GetCompanyTripBookingStates([FromQuery] CompanyTripBookingStateParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<CompanyTripBookingStateModel> rows = await _unitOfWork.CompanyTrip.GetCompanyTripBookingStatesPaged(parameters, language);

            SetPagination(rows.MetaData, parameters);

            List<CompanyTripBookingStateDto> rowsDto = _mapper.Map<List<CompanyTripBookingStateDto>>(rows);

            return rowsDto;
        }
    }
}
