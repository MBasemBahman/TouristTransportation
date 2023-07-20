using Contracts.Logger;
using Dashboard.Areas.AccountEntity.Models;
using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.AccountEntity.Controllers
{
    [Area("AccountEntity")]
    [Authorize(DashboardViewEnum.AccountType, AccessLevelEnum.View)]
    public class AccountTypeController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public AccountTypeController(ILoggerManager logger, IMapper mapper,
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

            AccountTypeFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] AccountTypeFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AccountTypeParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<AccountTypeModel> data = await _unitOfWork.Account.GetAccountTypesPaged(parameters, otherLang);

            List<AccountTypeDto> resultDto = _mapper.Map<List<AccountTypeDto>>(data);

            DataTable<AccountTypeDto> dataTableManager = new();

            DataTableResult<AccountTypeDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Account.GetAccountTypesCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            AccountTypeDto data = _mapper.Map<AccountTypeDto>(_unitOfWork.Account.GetAccountTypeById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.AccountType, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            AccountTypeCreateOrEditModel model = new();

            if (id > 0)
            {
                AccountType dataDB = await _unitOfWork.Account.FindAccountTypeById(id, trackChanges: false);
                model = _mapper.Map<AccountTypeCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.AccountTypeLangs ??= new List<AccountTypeLangModel>();

                    if (model.AccountTypeLangs.All(a => a.Language != language))
                    {
                        model.AccountTypeLangs.Add(new AccountTypeLangModel
                        {
                            Language = language
                        });
                    }
                }

                #endregion
            }

            SetViewData(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.AccountType, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, AccountTypeCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                AccountType dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<AccountType>(model);


                    _unitOfWork.Account.CreateAccountType(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Account.FindAccountTypeById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);
                }

                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }
            SetViewData(id);
            return View(model);
        }

        [Authorize(DashboardViewEnum.AccountType, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            AccountType data = await _unitOfWork.Account.FindAccountTypeById(id, trackChanges: false);

            return View(data != null &&
                !_unitOfWork.Account.GetAccounts(new AccountParameters
                {
                    Fk_AccountType = id
                }).Any());
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.AccountType, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Account.DeleteAccountType(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            ViewData["id"] = id;
        }

    }
}
