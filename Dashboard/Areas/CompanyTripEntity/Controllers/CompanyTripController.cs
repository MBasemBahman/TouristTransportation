using Contracts.Logger;
using Dashboard.Areas.CompanyTripEntity.Models;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.MainDataModels;
using Entities.RequestFeatures;

namespace Dashboard.Areas.CompanyTripEntity.Controllers
{
    [Area("CompanyTripEntity")]
    [Authorize(DashboardViewEnum.CompanyTrip, AccessLevelEnum.View)]
    public class CompanyTripController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public CompanyTripController(ILoggerManager logger, IMapper mapper,
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

            CompanyTripFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData(id: 0);

            return View(filter);
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripDto data = _mapper.Map<CompanyTripDto>(_unitOfWork.CompanyTrip
                .GetCompanyTripById(id, otherLang));

           

            data.CompanyTripAttachments = _mapper.Map<List<CompanyTripAttachmentDto>>
                (_unitOfWork.CompanyTrip.GetCompanyTripAttachments(new CompanyTripAttachmentParameters
                {
                    Fk_CompanyTrip = id
                }, language: null).ToList());
            return View(data);
        }

        public IActionResult Profile(int id, int returnItem = (int)CompanyTripProfileItems.Details)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripDto data = _mapper.Map<CompanyTripDto>(_unitOfWork.CompanyTrip
                .GetCompanyTripById(id, otherLang));

            ViewData["otherLang"] = otherLang;

            ViewData["returnItem"] = returnItem;

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] CompanyTripFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<CompanyTripModel> data = await _unitOfWork.CompanyTrip.GetCompanyTripsPaged(parameters, otherLang);

            List<CompanyTripDto> resultDto = _mapper.Map<List<CompanyTripDto>>(data);

            DataTable<CompanyTripDto> dataTableManager = new();

            DataTableResult<CompanyTripDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.CompanyTrip.GetCompanyTripsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }


        [Authorize(DashboardViewEnum.CompanyTrip, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripCreateOrEditModel model = new();

            if (id > 0)
            {
                CompanyTrip dataDB = await _unitOfWork.CompanyTrip.FindCompanyTripById(id, trackChanges: false);
                model = _mapper.Map<CompanyTripCreateOrEditModel>(dataDB);

                model.ImageUrl = dataDB.StorageUrl + dataDB.ImageUrl;

                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.CompanyTripLangs ??= new List<CompanyTripLangModel>();

                    if (model.CompanyTripLangs.All(a => a.Language != language))
                    {
                        model.CompanyTripLangs.Add(new CompanyTripLangModel
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
        [Authorize(DashboardViewEnum.CompanyTrip, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEditWizard(int id, CompanyTripCreateOrEditModel model, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return BadRequest(errorMessages);
            }
            try
            {
                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                CompanyTrip dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<CompanyTrip>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.CompanyTrip.CreateCompanyTrip(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.CompanyTrip.FindCompanyTripById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    dataDB.LastModifiedBy = auth.UserName;
                }

                if (imageFile != null)
                {
                    dataDB.ImageUrl = await _unitOfWork.Account.UploadAccountImage(_environment.WebRootPath, imageFile);
                    dataDB.StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString());
                }

                await _unitOfWork.Save();

                return Ok(new CompanyTripModel
                {
                    Id = dataDB.Id
                });
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            return BadRequest(new List<string>() { ViewData[ViewDataConstants.Error].ToString() });
        }

        [Authorize(DashboardViewEnum.CompanyTrip, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            CompanyTrip data = await _unitOfWork.CompanyTrip.FindCompanyTripById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.CompanyTrip, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.CompanyTrip.DeleteCompanyTrip(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["id"] = id;
            ViewData["CompanyTripStates"] = _unitOfWork.CompanyTrip.GetCompanyTripStatesLookUp(new CompanyTripStateParameters(), otherLang);
        }

    }
}
