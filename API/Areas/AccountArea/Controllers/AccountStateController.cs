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
    public class AccountStateController : ExtendControllerBase
    {
        public AccountStateController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpPost]
        [Route(nameof(ChangeClientToSeller))]
        public async Task<bool> ChangeClientToSeller()
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
            
            if (auth.Fk_AccountState != (int)AccountStateEnum.Active || auth.Fk_AccountType != (int)AccountTypeEnum.Client)
            {
                throw new Exception("Your account has been banned!");
            }

            Account account = await _unitOfWork.Account.FindAccountById(auth.Fk_Account, trackChanges: true);

            account.Fk_AccountState = (int)AccountStateEnum.RequestToBeSeller;

            await _unitOfWork.Save();
            
            return true;
        }
    }
    
}

