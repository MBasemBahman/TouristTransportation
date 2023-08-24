using API.Areas.AccountArea.Models;
using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.AccountArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Account")]
    [ApiExplorerSettings(GroupName = "Account")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class AccountController : ExtendControllerBase
    {
        public AccountController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetDrivers))]
        public async Task<IEnumerable<AccountDto>> GetDrivers([FromQuery] AccountParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            parameters.Fk_AccountType = (int)AccountTypeEnum.Driver;
            
            PagedList<AccountModel> accounts = await _unitOfWork.Account.GetAccountsPaged(parameters, language);

            SetPagination(accounts.MetaData, parameters);

            List<AccountDto> accountsDto = _mapper.Map<List<AccountDto>>(accounts);

            return accountsDto;
        }

        [HttpGet]
        [Route(nameof(GetDriver))]
        public AccountDto GetDriver([FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountModel account = _unitOfWork.Account.GetAccountById(id, language);

            if (account.Fk_AccountType != (int)AccountTypeEnum.Driver)
            {
                throw new Exception("Bad Request!");
            }

            AccountDto accountDto = _mapper.Map<AccountDto>(account);

            return accountDto;
        }
    }
}
