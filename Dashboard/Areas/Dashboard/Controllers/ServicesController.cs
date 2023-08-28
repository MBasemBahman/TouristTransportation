﻿using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.CoreServicesModels.TripModels;

namespace Dashboard.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServicesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

        public ServicesController(IMapper mapper, UnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        public ActionResult<List<AreaModel>> GetAreasByFilters(AreaParameters parameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            return _unitOfWork.MainData.GetAreas(parameters, otherLang).ToList();
        }
        
        public ActionResult<List<AccountModel>> GetAccountsByFilters(AccountParameters parameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            return _unitOfWork.Account.GetAccounts(parameters, otherLang).ToList();
        }
        
        public ActionResult<List<CompanyTripBookingHistoryModel>> GetCompanyTripBookingHistoriesByFilters(CompanyTripBookingHistoryParameters parameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            return _unitOfWork.CompanyTrip.GetCompanyTripBookingHistories(parameters, otherLang).ToList();
        }

        public ActionResult<TripPointModel> GetTripPointById(int id)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];
            
            return _unitOfWork.Trip.GetTripPointById(id, language);
        }
    }
}
