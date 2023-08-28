using API.Areas.CompanyTripArea.Models;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.CompanyTripModels;
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

            parameters.Fk_AccountForBooking = auth.Fk_Account;

            PagedList<CompanyTripBookingModel> CompanyTripBookings = await _unitOfWork.CompanyTrip.GetCompanyTripBookingsPaged(parameters, language);

            SetPagination(CompanyTripBookings.MetaData, parameters);

            List<CompanyTripBookingDto> CompanyTripBookingsDto = _mapper.Map<List<CompanyTripBookingDto>>(CompanyTripBookings);

            return CompanyTripBookingsDto;
        }

        [HttpGet]
        [Route(nameof(GetCompanyTripBooking))]
        public CompanyTripBookingDto GetCompanyTripBooking([FromQuery, BindRequired] int Id)
        {
            _ = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripBookingModel CompanyTripBooking = _unitOfWork.CompanyTrip.GetCompanyTripBookingById(Id, language);

            CompanyTripBookingDto CompanyTripBookingDto = _mapper.Map<CompanyTripBookingDto>(CompanyTripBooking);

            return CompanyTripBookingDto;
        }

        [HttpPost]
        [Route(nameof(CreateCompanyTripBooking))]
        public CompanyTripBookingDto CreateCompanyTripBooking([FromBody, BindRequired] CompanyTripBookingCreateModel model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripBooking companyTripBooking = _mapper.Map<CompanyTripBooking>(model);

            CompanyTripModel companyTrip = _unitOfWork.CompanyTrip.GetCompanyTripById(model.Fk_CompanyTrip, language: null);
            CurrencyModel currency = _unitOfWork.MainData.GetCurrencyById(model.Fk_Currency, language: null);

            if (companyTripBooking.MembersCount == 0)
            {
                companyTripBooking.MembersCount = 1;
            }

            companyTripBooking.Fk_Account = auth.Fk_Account;
            companyTripBooking.Fk_CompanyTripBookingState = (int)CompanyTripBookingStateEnum.Pending;
            companyTripBooking.CurrencyRate = currency.RateInPounds;
            companyTripBooking.Price = companyTrip.Price * companyTripBooking.MembersCount;
            companyTripBooking.CreatedBy = auth.Name;

            _unitOfWork.CompanyTrip.CreateCompanyTripBooking(companyTripBooking);
            _unitOfWork.Save().Wait();

            CompanyTripBookingModel CompanyTripBooking = _unitOfWork.CompanyTrip.GetCompanyTripBookingById(companyTripBooking.Id, language);

            CompanyTripBookingDto CompanyTripBookingDto = _mapper.Map<CompanyTripBookingDto>(CompanyTripBooking);

            return CompanyTripBookingDto;
        }

        [HttpDelete]
        [Route(nameof(CancelCompanyTripBooking))]
        public async Task<CompanyTripBookingDto> CancelCompanyTripBooking([FromQuery, BindRequired] int Id)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripBooking companyTripBooking = await _unitOfWork.CompanyTrip.FindCompanyTripBookingById(Id, trackChanges: true);

            if (auth.Fk_Account != companyTripBooking.Fk_Account)
            {
                throw new Exception("Not Allowed!");
            }
            companyTripBooking.Fk_CompanyTripBookingState = (int)CompanyTripBookingStateEnum.Canceled;

            _unitOfWork.CompanyTrip
                           .UpdateCompanyTripBookingHistory(companyTripBooking.Id,
                               companyTripBooking.Fk_CompanyTripBookingState,
                               (int)CompanyTripBookingStateEnum.Canceled, companyTripBooking.Notes);

            companyTripBooking.LastModifiedBy = auth.Name;

            _unitOfWork.Save().Wait();

            CompanyTripBookingModel CompanyTripBooking = _unitOfWork.CompanyTrip.GetCompanyTripBookingById(Id, language);

            CompanyTripBookingDto CompanyTripBookingDto = _mapper.Map<CompanyTripBookingDto>(CompanyTripBooking);

            return CompanyTripBookingDto;
        }
    }
}
