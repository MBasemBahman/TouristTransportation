using API.Areas.CompanyTripArea.Models;
using Entities.CoreServicesModels.CompanyTripModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.CompanyTripArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("CompanyTrip")]
    [ApiExplorerSettings(GroupName = "CompanyTrip")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class CompanyTripBookingController : ExtendControllerBase
    {
        public CompanyTripBookingController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {
        }

        [HttpGet]
        [Route(nameof(GetCompanyTripBookings))]
        public async Task<IEnumerable<CompanyTripBookingDto>> GetCompanyTripBookings([FromQuery] CompanyTripBookingParameters parameters)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            parameters.Fk_Account = auth.Fk_Account;

            PagedList<CompanyTripBookingModel> CompanyTripBookings = await _unitOfWork.CompanyTrip.GetCompanyTripBookingsPaged(parameters, language);

            SetPagination(CompanyTripBookings.MetaData, parameters);

            List<CompanyTripBookingDto> CompanyTripBookingsDto = _mapper.Map<List<CompanyTripBookingDto>>(CompanyTripBookings);

            return CompanyTripBookingsDto;
        }

        [HttpGet]
        [Route(nameof(GetCompanyTripBooking))]
        public CompanyTripBookingDto GetCompanyTripBooking([FromQuery, BindRequired] int Id)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripBookingModel CompanyTripBooking = _unitOfWork.CompanyTrip.GetCompanyTripBookingById(Id, language);

            CompanyTripBookingDto CompanyTripBookingDto = _mapper.Map<CompanyTripBookingDto>(CompanyTripBooking);

            return CompanyTripBookingDto;
        }

    }
}
