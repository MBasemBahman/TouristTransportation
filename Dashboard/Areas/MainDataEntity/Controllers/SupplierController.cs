using Contracts.Logger;
using Dashboard.Areas.MainDataEntity.Models;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.MainDataEntity.Controllers
{
    [Area("MainDataEntity")]
    [Authorize(DashboardViewEnum.Supplier, AccessLevelEnum.View)]
    public class SupplierController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public SupplierController(ILoggerManager logger, IMapper mapper,
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

            SupplierFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] SupplierFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            SupplierParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<SupplierModel> data = await _unitOfWork.MainData.GetSuppliersPaged(parameters, otherLang);

            List<SupplierDto> resultDto = _mapper.Map<List<SupplierDto>>(data);

            DataTable<SupplierDto> dataTableManager = new();

            DataTableResult<SupplierDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.MainData.GetSuppliersCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            SupplierDto data = _mapper.Map<SupplierDto>(_unitOfWork.MainData.GetSupplierById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Supplier, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            SupplierCreateOrEditModel model = new();

            if (id > 0)
            {
                Supplier dataDB = await _unitOfWork.MainData.FindSupplierById(id, trackChanges: false);
                model = _mapper.Map<SupplierCreateOrEditModel>(dataDB);

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.SupplierLangs ??= new List<SupplierLangModel>();

                    if (model.SupplierLangs.All(a => a.Language != language))
                    {
                        model.SupplierLangs.Add(new SupplierLangModel
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
        [Authorize(DashboardViewEnum.Supplier, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, SupplierCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                Supplier dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<Supplier>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.MainData.CreateSupplier(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.MainData.FindSupplierById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    dataDB.LastModifiedBy = auth.UserName;
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

        [Authorize(DashboardViewEnum.Supplier, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            Supplier data = await _unitOfWork.MainData.FindSupplierById(id, trackChanges: false);

            return View(data != null &&
                !_unitOfWork.Account.GetAccounts(new Entities.CoreServicesModels.AccountModels.AccountParameters
                {
                    Fk_Supplier = id
                },language:null).Any());
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.Supplier, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.MainData.DeleteSupplier(id);
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
