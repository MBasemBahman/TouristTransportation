using Contracts.Logger;
using Dashboard.Areas.AccountEntity.Models;
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.AccountModels;
using Entities.RequestFeatures;

namespace Dashboard.Areas.AccountEntity.Controllers
{
    [Area("AccountEntity")]
    [Authorize(DashboardViewEnum.Account, AccessLevelEnum.View)]
    public class AccountController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public AccountController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }

        public IActionResult Index(int id, bool ProfileLayOut = false)
        {
            AccountFilter filter = new()
            {
                Id = id,
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData(0);
            
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] AccountFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            AccountParameters parameters = new()
            {
                SearchColumns = "Id,Name",
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<AccountModel> data = await _unitOfWork.Account.GetAccountsPaged(parameters,otherLang);

            List<AccountDto> resultDto = _mapper.Map<List<AccountDto>>(data);

            DataTable<AccountDto> dataTableManager = new();

            DataTableResult<AccountDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Account.GetAccountsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountDto data = _mapper.Map<AccountDto>(_unitOfWork.Account.GetAccountById(id,otherLang));

            return View(data);
        }

        public IActionResult Profile(int id, int returnItem = (int)AccountProfileItems.Details)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountDto data = _mapper.Map<AccountDto>(_unitOfWork.Account
                .GetAccountById(id,otherLang));

            ViewData["returnItem"] = returnItem;
            ViewData["otherLang"] = otherLang;

            return View(data);
        }

        [Authorize(DashboardViewEnum.Account, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0, bool isProfile = false)
        {
            AccountCreateOrEditModel model = new();
            
            if (id > 0)
            {
                Account countryDB = await _unitOfWork.Account.FindAccountById(id, trackChanges: false);
                model = _mapper.Map<AccountCreateOrEditModel>(countryDB);
                model.User = _mapper.Map<UserCreateModel>(countryDB.User);

                model.ImageUrl = countryDB.StorageUrl + countryDB.ImageUrl;
            }


            SetViewData(id, isProfile);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.Account, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, AccountCreateOrEditModel model, bool isProfile = false)
        {
            if (!ModelState.IsValid)
            {
                SetViewData(id, isProfile);

                return View(model);
            }
            try
            {
                model.Fk_Supplier = model.Fk_Supplier > 0 ? model.Fk_Supplier : null;
                model.Fk_Currency = model.Fk_Currency > 0 ? model.Fk_Currency : null;
                model.User.Name = $"{model.FirstName} {model.LastName}";
                
                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                
                Account dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<Account>(model);
                    dataDB.User = _mapper.Map<User>(model.User);

                    dataDB.CreatedBy = auth.UserName;
                    
                    dataDB.User.Password = _unitOfWork.Account.GeneratePassword(model.User.Password);

                    _unitOfWork.Account.CreateAccount(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Account.FindAccountById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    if (!string.IsNullOrEmpty(model.User.Password))
                    {
                        dataDB.User.Password = _unitOfWork.Account.GeneratePassword(model.User.Password);
                    }
                    
                    dataDB.LastModifiedBy = auth.UserName;
                }

                IFormFile imageFile = HttpContext.Request.Form.Files["ImageFile"];

                if (imageFile != null)
                {
                    dataDB.ImageUrl = await _unitOfWork.Account.UploadAccountImage(_environment.WebRootPath, imageFile);
                    dataDB.StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString());
                }

                await _unitOfWork.Save();

                if (isProfile)
                {
                    return RedirectToAction("Profile", "Account", new
                    {
                        area = "AccountEntity",
                        id = dataDB.Id,
                    });
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }
            SetViewData(id, isProfile);
            return View(model);
        }

        [Authorize(DashboardViewEnum.Account, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            Account data = await _unitOfWork.Account.FindAccountById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.Account, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Account.DeleteAccount(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id, bool isProfile = false)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["id"] = id;
            ViewData["isProfile"] = isProfile;
            ViewData["AccountType"] = _unitOfWork.Account.GetAccountTypesLookUp(new AccountTypeParameters(), otherLang);
            ViewData["AccountState"] = _unitOfWork.Account.GetAccountStatesLookUp(new AccountStateParameters(), otherLang);
            ViewData["Supplier"] = _unitOfWork.MainData.GetSuppliersLookUp(new SupplierParameters(), otherLang);
            ViewData["Currency"] = _unitOfWork.MainData.GetCurrenciesLookUp(new CurrencyParameters(), otherLang);

        }

    }
}
