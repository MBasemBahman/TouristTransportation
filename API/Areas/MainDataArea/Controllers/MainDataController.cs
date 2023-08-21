using API.Areas.MainDataArea.Models;
using Entities.CoreServicesModels.MainDataModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.MainDataArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("MainData")]
    [ApiExplorerSettings(GroupName = "MainData")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class MainDataController : ExtendControllerBase
    {
        public MainDataController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetCurrencies))]
        public async Task<IEnumerable<CurrencyDto>> GetCurrencies([FromQuery] CurrencyParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<CurrencyModel> rows = await _unitOfWork.MainData.GetCurrenciesPaged(parameters, language);

            SetPagination(rows.MetaData, parameters);

            List<CurrencyDto> rowsDto = _mapper.Map<List<CurrencyDto>>(rows);

            return rowsDto;
        }
        
        [HttpGet]
        [Route(nameof(GetCountries))]
        public async Task<IEnumerable<CountryDto>> GetCountries([FromQuery] CountryParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<CountryModel> rows = await _unitOfWork.MainData.GetCountriesPaged(parameters, language);

            SetPagination(rows.MetaData, parameters);

            List<CountryDto> rowsDto = _mapper.Map<List<CountryDto>>(rows);

            return rowsDto;
        }
        
        [HttpGet]
        [Route(nameof(GetAreas))]
        public async Task<IEnumerable<AreaDto>> GetAreas([FromQuery] AreaParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<AreaModel> rows = await _unitOfWork.MainData.GetAreasPaged(parameters, language);

            SetPagination(rows.MetaData, parameters);

            List<AreaDto> rowsDto = _mapper.Map<List<AreaDto>>(rows);

            return rowsDto;
        }
    }
}
