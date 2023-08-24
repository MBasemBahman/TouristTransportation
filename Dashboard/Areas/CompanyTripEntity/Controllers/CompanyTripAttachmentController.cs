using Contracts.Logger;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;

namespace Dashboard.Areas.CompanyTripEntity.Controllers
{
    [Area("CompanyTripEntity")]
    [Authorize(DashboardViewEnum.CompanyTripAttachment, AccessLevelEnum.View)]
    public class CompanyTripAttachmentController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public CompanyTripAttachmentController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }

        public IActionResult Index(int fk_CompanyTrip = 0)
        {
            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];
            
            return View(fk_CompanyTrip);
        }
        
        [Authorize(DashboardViewEnum.CompanyTripAttachment, AccessLevelEnum.Create)]
        public async Task<IActionResult> Upload(int fk_CompanyTrip)
        {
            IFormFile file = HttpContext.Request.Form.Files["file"];
            if (file != null)
            {
                CompanyTripAttachment attachment = new()
                {
                    FileUrl = await _unitOfWork.CompanyTrip.UploadCompanyTripAttachment(_environment.WebRootPath, file),
                    StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString()),
                    Fk_CompanyTrip = fk_CompanyTrip,
                    FileName = file.FileName,
                    FileLength = file.Length,
                    FileType = file.ContentType,
                };
                _unitOfWork.CompanyTrip.CreateCompanyTripAttachment(attachment);
                await _unitOfWork.Save();
            }
            return NoContent();
        }

        [Authorize(DashboardViewEnum.CompanyTripAttachment, AccessLevelEnum.CreateOrEdit)]
        public ActionResult<List<CompanyTripAttachmentModel>> GetCompanyTripAttachments(int fk_CompanyTrip)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            return _unitOfWork.CompanyTrip.GetCompanyTripAttachments(new CompanyTripAttachmentParameters { Fk_CompanyTrip = fk_CompanyTrip }, otherLang).ToList();
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.CompanyTripAttachment, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.CompanyTrip.DeleteCompanyTripAttachment(id);
            await _unitOfWork.Save();

            return NoContent();
        }

    }
}
