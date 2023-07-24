using API.Areas.CompanyTripArea.Models;
using Entities.CoreServicesModels.CompanyTripModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.CompanyTripArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("CompanyTrip")]
    [ApiExplorerSettings(GroupName = "CompanyTrip")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class CompanyTripController : ExtendControllerBase
    {
        public CompanyTripController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetCompanyTrips))]
        public async Task<IEnumerable<CompanyTripDto>> GetCompanyTrips([FromQuery] CompanyTripParameters parameters)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            if (auth.Fk_Account == 0)
            {
                throw new Exception("Not Allowed");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            PagedList<CompanyTripModel> companyTrips = await _unitOfWork.CompanyTrip.GetCompanyTripsPaged(parameters, language);

            SetPagination(companyTrips.MetaData, parameters);

            List<CompanyTripDto> companyTripsDto = _mapper.Map<List<CompanyTripDto>>(companyTrips);

            return companyTripsDto;
        }

        [HttpGet]
        [Route(nameof(GetCompanyTrip))]
        public async Task<CompanyTripDto> GetCompanyTrip(
          [FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            //For My Reaction
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripModel companyTrip = _unitOfWork.CompanyTrip.GetCompanyTripById(id, language);

            CompanyTripDto companyTripDto = _mapper.Map<CompanyTripDto>(companyTrip);

            companyTripDto = await SetAttachments(companyTripDto);

            return companyTripDto;
        }

        // Helper Methods
        private async Task<CompanyTripDto> SetAttachments(CompanyTripDto companyTrip)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];


            if (companyTrip.AttachmentsCount > 0 && companyTrip.Id > 0)
            {
                companyTrip.Attachments = _mapper.Map<IEnumerable<CompanyTripAttachmentDto>>(
                    await _unitOfWork.CompanyTrip.GetCompanyTripAttachmentsPaged(new CompanyTripAttachmentParameters
                    {
                        Fk_CompanyTrip = companyTrip.Id,
                        PageNumber = 1,
                        PageSize = 5,
                    }, language));
            }

            return companyTrip;
        }
    }
}
