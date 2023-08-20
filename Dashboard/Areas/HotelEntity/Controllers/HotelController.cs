using Contracts.Logger;
using Dashboard.Areas.HotelEntity.Models;
using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.MainDataModels;
using Entities.RequestFeatures;

namespace Dashboard.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.Hotel, AccessLevelEnum.View)]
    public class HotelController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public HotelController(ILoggerManager logger, IMapper mapper,
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

            HotelFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData(id: 0);
            
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] HotelFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<HotelModel> data = await _unitOfWork.Hotel.GetHotelsPaged(parameters, otherLang);

            List<HotelDto> resultDto = _mapper.Map<List<HotelDto>>(data);

            DataTable<HotelDto> dataTableManager = new();

            DataTableResult<HotelDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Hotel.GetHotelsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            HotelDto data = _mapper.Map<HotelDto>(_unitOfWork.Hotel.GetHotelById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Hotel, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            HotelCreateOrEditModel model = new()
            {
                HotelFeatures = new List<int>()
            };

            if (id > 0)
            {
                Hotel dataDB = await _unitOfWork.Hotel.FindHotelById(id, trackChanges: false);
                model = _mapper.Map<HotelCreateOrEditModel>(dataDB);

                model.ImageUrl = dataDB.StorageUrl + dataDB.ImageUrl;
                
                model.HotelFeatures = _unitOfWork.Hotel.GetHotelSelectedFeatures(new HotelSelectedFeaturesParameters
                {
                    Fk_Hotel = id,
                }, otherLang).Select(a => a.Fk_HotelFeature).ToList();

                if (model.Fk_Area != null)
                {
                    ViewData["Fk_Country"] = _unitOfWork.MainData.GetAreaById((int)model.Fk_Area, otherLang).Fk_Country;
                }
                
                #region Check for new Languages

                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    model.HotelLangs ??= new List<HotelLangModel>();
                
                    if (model.HotelLangs.All(a => a.Language != language))
                    {
                        model.HotelLangs.Add(new HotelLangModel
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
        [Authorize(DashboardViewEnum.Hotel, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEditWizard(int id, HotelCreateOrEditModel model)
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
                Hotel dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<Hotel>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Hotel.CreateHotel(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Hotel.FindHotelById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    dataDB.LastModifiedBy = auth.UserName;
                }

                IFormFile imageFile = HttpContext.Request.Form.Files["ImageFile"];

                if (imageFile != null)
                {
                    dataDB.ImageUrl = await _unitOfWork.Account.UploadAccountImage(_environment.WebRootPath, imageFile);
                    dataDB.StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString());
                }
                
                await _unitOfWork.Save();

                return Ok(new HotelModel
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

        [Authorize(DashboardViewEnum.Hotel, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            Hotel data = await _unitOfWork.Hotel.FindHotelById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.Hotel, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Hotel.DeleteHotel(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            ViewData["id"] = id;
            ViewData["Areas"] = _unitOfWork.MainData.GetAreasLookUp(new AreaParameters(), otherLang);
            ViewData["Countries"] = _unitOfWork.MainData.GetCountriesLookUp(new CountryParameters(), otherLang);
            ViewData["HotelFeatureCategories"] = _unitOfWork.Hotel.GetHotelFeatureCategories(new HotelFeatureCategoryParameters
            {
                IncludeHotelFeatures = true
            }, otherLang).ToList();
        }

    }
}
