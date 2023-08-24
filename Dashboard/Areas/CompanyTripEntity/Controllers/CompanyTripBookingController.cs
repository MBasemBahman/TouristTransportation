﻿using Contracts.Logger;
using Dashboard.Areas.CompanyTripEntity.Models;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.CompanyTripModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.CompanyTripEntity.Controllers
{
    [Area("CompanyTripEntity")]
    [Authorize(DashboardViewEnum.CompanyTripBooking, AccessLevelEnum.View)]
    public class CompanyTripBookingController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public CompanyTripBookingController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }

        public IActionResult Index(int id, int fk_CompanyTrip = 0, bool ProfileLayOut = false)
        {

            CompanyTripBookingFilter filter = new()
            {
                Id = id,
                Fk_CompanyTrip = fk_CompanyTrip
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] CompanyTripBookingFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripBookingParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<CompanyTripBookingModel> data = await _unitOfWork.CompanyTrip.GetCompanyTripBookingsPaged(parameters, otherLang);

            List<CompanyTripBookingDto> resultDto = _mapper.Map<List<CompanyTripBookingDto>>(data);

            DataTable<CompanyTripBookingDto> dataTableManager = new();

            DataTableResult<CompanyTripBookingDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.CompanyTrip.GetCompanyTripBookingsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CompanyTripBookingDto data = _mapper.Map<CompanyTripBookingDto>(_unitOfWork.CompanyTrip.GetCompanyTripBookingById(id, otherLang));

            return View(data);
        }

        [Authorize(DashboardViewEnum.CompanyTripBooking, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0, int fk_CompanyTrip = 0)
        {
            CompanyTripBookingCreateOrEditModel model = new()
            {
                Fk_CompanyTrip = fk_CompanyTrip,
                Date = DateTime.Today
            };

            if (id > 0)
            {
                CompanyTripBooking dataDB = await _unitOfWork.CompanyTrip.FindCompanyTripBookingById(id, trackChanges: false);
                model = _mapper.Map<CompanyTripBookingCreateOrEditModel>(dataDB);
            }

            SetViewData(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.CompanyTripBooking, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, CompanyTripBookingCreateOrEditModel model)
        {

            if (!ModelState.IsValid)
            {
                SetViewData(id);

                return View(model);
            }
            try
            {

                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                CompanyTripBooking dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<CompanyTripBooking>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.CompanyTrip.CreateCompanyTripBooking(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.CompanyTrip.FindCompanyTripBookingById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    dataDB.LastModifiedBy = auth.UserName;
                }

                await _unitOfWork.Save();

                return RedirectToAction("Profile", "CompanyTrip", new
                {
                    Id = dataDB.Fk_CompanyTrip,
                    returnItem = (int)CompanyTripProfileItems.CompanyTripBooking
                });
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }
            SetViewData(id);
            return View(model);
        }

        [Authorize(DashboardViewEnum.CompanyTripBooking, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            CompanyTripBooking data = await _unitOfWork.CompanyTrip.FindCompanyTripBookingById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.CompanyTripBooking, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.CompanyTrip.DeleteCompanyTripBooking(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            ViewData["id"] = id;

            ViewData["CompanyTrip"] = _unitOfWork.CompanyTrip.GetCompanyTripStatesLookUp(new CompanyTripStateParameters(), otherLang);
            
            ViewData["Currency"] = _unitOfWork.MainData.GetCurrenciesLookUp(new CurrencyParameters(), otherLang);
            
            ViewData["CompanyTripBookingState"] = _unitOfWork.CompanyTrip
                .GetCompanyTripBookingStatesLookUp(new CompanyTripBookingStateParameters(), otherLang);
        }

    }
}
