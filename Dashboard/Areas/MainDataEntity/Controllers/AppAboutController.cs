using Contracts.Logger;
using Dashboard.Areas.MainDataEntity.Models;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.MainDataEntity.Controllers
{
    [Area("MainDataEntity")]
    [Authorize(DashboardViewEnum.AppAbout, AccessLevelEnum.View)]
    public class AppAboutController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public AppAboutController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Details()
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            AppAboutModel model = _unitOfWork.MainData.GetAppAbouts(new RequestParameters(), otherLang).Any() ?
                _unitOfWork.MainData.GetAppAbouts(new RequestParameters(), otherLang).FirstOrDefault()
                : new AppAboutModel();


            AppAboutDto data = _mapper.Map<AppAboutDto>(model);

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(data);
        }

        [Authorize(DashboardViewEnum.AppAbout, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit()
        {
            AppAbout dataDb = await _unitOfWork.MainData.FindAppAbout(trackChanges: false);

            if (dataDb == null)
            {
                return View(new AppAboutCreateOrEditModel());
            }

            AppAboutCreateOrEditModel model = _mapper.Map<AppAboutCreateOrEditModel>(dataDb);

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (dataDb.AppAboutLangs.All(b => b.Language != language))
                {
                    dataDb.AppAboutLangs.Add(new AppAboutLang
                    {
                        AboutCompany = dataDb.AboutCompany,
                        AboutApp = dataDb.AboutApp,
                        TermsAndConditions = dataDb.TermsAndConditions,
                        QuestionsAndAnswer = dataDb.QuestionsAndAnswer,
                        Language = language
                    });
                }
            }
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.AppAbout, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(AppAboutCreateOrEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

                AppAbout dataDb = await _unitOfWork.MainData.FindAppAbout(trackChanges: true);

                if (dataDb == null)
                {
                    dataDb = _mapper.Map<AppAbout>(model);
                    dataDb.CreatedBy = auth.UserName;

                    _unitOfWork.MainData.CreateAppAbout(dataDb);
                }
                else
                {
                    _ = _mapper.Map(model, dataDb);

                    dataDb.LastModifiedBy = auth.UserName;
                }

                await _unitOfWork.Save();

                return RedirectToAction(nameof(Details));
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            return View(model);
        }
    }
}
