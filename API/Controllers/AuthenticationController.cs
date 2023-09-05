﻿using API.Areas.AccountArea.Models;
using API.Models;
using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.UserModels;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "Authentication")]
    [Route("v{version:apiVersion}/[controller]")]
    public class AuthenticationController : ExtendControllerBase
    {
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IAuthenticationManager authManager,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {
            _authManager = authManager;
        }

        [HttpPost]
        [Route(nameof(Login))]
        [AllowAnonymous]
        public async Task<UserAuthenticatedDto> Login([FromBody] UserForAuthenticationDto model)
        {
            model.UserName = RegexService.GetUserName(model.UserName);

            UserAuthenticatedDto auth = await _authManager.Authenticate(model, IpAddress());

            SetToken(auth.TokenResponse);
            SetRefresh(auth.RefreshTokenResponse);

            return auth;
        }

        [HttpPost]
        [Route(nameof(RegisterUserWithAccount))]
        [AllowAnonymous]
        public async Task<UserAuthenticatedDto> RegisterUserWithAccount([FromBody] UserForRegistrationDto model)
        {
            if (model.EmailAddress.IsExisting() && _unitOfWork.Account.GetAccounts(new AccountParameters
            {
                EmailAddress = model.EmailAddress
            }, LanguageEnum.en).Any())
            {
                throw new Exception("Email Address already registered!");
            }

            model.UserName = RegexService.GetUserName(model.UserName);

            User user = new()
            {
                Name = $"{model.FirstName} {model.LastName}",
                UserName = model.UserName,
                EmailAddress = model.EmailAddress,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Account = new Account
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Fk_AccountState = (int)AccountStateEnum.Active,
                    Fk_AccountType = (int)AccountTypeEnum.Client,
                },
                Culture = model.Culture
            };

            await _unitOfWork.User.CreateUser(user);
            await _unitOfWork.Save();

            UserAuthenticatedDto auth = await _authManager.Authenticate(new UserForAuthenticationDto
            {
                UserName = model.UserName,
                Password = model.Password,
            }, IpAddress());

            SetToken(auth.TokenResponse);
            SetRefresh(auth.RefreshTokenResponse);

            return auth;
        }

        [HttpPut]
        [Route(nameof(EditAccount))]
        public async Task<AccountDto> EditAccount([FromForm] AuthForEditDto model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
            
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            Account account = await _unitOfWork.Account.FindAccountById(auth.Id, trackChanges: true);

            if (account.Fk_AccountType == (int)AccountTypeEnum.Client)
            {
                account.User.Name = $"{model.FirstName} {model.LastName}";
                account.User.PhoneNumber = model.PhoneNumber;
                
                account.FirstName = model.FirstName;
                account.LastName = model.LastName;
                
                if (model.ImageFile != null)
                {
                    account.ImageUrl = await _unitOfWork.Account.UploadAccountImage(_environment.WebRootPath, model.ImageFile);
                    account.StorageUrl = GetBaseUri();
                }
                
                await _unitOfWork.Save();
            }

            return _mapper.Map<AccountDto>(_unitOfWork.Account.GetAccountById(auth.Id, language));
        } 
        
        [HttpPut]
        [Route(nameof(ChangePassword))]
        public async Task<bool> ChangePassword(
           [FromBody] ChangePasswordDto model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            await _unitOfWork.User.ChangePassword(auth.Id, model);
            await _unitOfWork.Save();

            return true;
        }

        [HttpPut]
        [Route(nameof(SetCulture))]
        public async Task<bool> SetCulture(
           [FromBody] UserForEditCultureDto model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            User user = await _unitOfWork.User.FindById(auth.Id, trackChanges: true);

            _ = _mapper.Map(model, user);

            await _unitOfWork.Save();

            return true;
        }

        [HttpPost]
        [Route(nameof(RefreshToken))]
        [AllowAnonymous]
        public async Task<UserAuthenticatedDto> RefreshToken(
            [FromBody] UserForTokenDto model)
        {
            model.Token = System.Net.WebUtility.UrlDecode(model.Token);
            model.Token = model.Token.Replace(" ", "+");

            UserAuthenticatedDto auth = await _authManager.Authenticate(model.Token, IpAddress());

            SetToken(auth.TokenResponse);
            SetRefresh(auth.RefreshTokenResponse);

            return auth;
        }

        [HttpPost]
        [Route(nameof(RevokeToken))]
        [AllowAnonymous]
        public async Task<bool> RevokeToken(
            [FromBody] UserForTokenDto model)
        {
            _ = await _authManager.Authenticate(model.Token, IpAddress());

            await _authManager.RevokeToken(model.Token, IpAddress());

            return true;
        }
    }
}
