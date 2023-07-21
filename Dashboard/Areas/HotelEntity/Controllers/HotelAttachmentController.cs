using Contracts.Logger;
using Dashboard.Areas.HotelEntity.Models;
using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.HotelModels;
using Entities.RequestFeatures;

namespace Dashboard.Areas.HotelEntity.Controllers
{
    [Area("HotelEntity")]
    [Authorize(DashboardViewEnum.HotelAttachment, AccessLevelEnum.View)]
    public class HotelAttachmentController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public HotelAttachmentController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }

        [Authorize(DashboardViewEnum.HotelAttachment, AccessLevelEnum.Create)]
        public async Task<IActionResult> Upload(int fk_Hotel)
        {
            IFormFile file = HttpContext.Request.Form.Files["file"];
            if (file != null)
            {
                HotelAttachment attachment = new()
                {
                    FileUrl = await _unitOfWork.Hotel.UploadHotelAttachment(_environment.WebRootPath, file),
                    StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString()),
                    Fk_Hotel = fk_Hotel,
                    FileName = file.FileName,
                    FileLength = file.Length,
                    FileType = file.ContentType,
                };
                _unitOfWork.Hotel.CreateHotelAttachment(attachment);
                await _unitOfWork.Save();
            }
            return NoContent();
        }

        [Authorize(DashboardViewEnum.HotelAttachment, AccessLevelEnum.CreateOrEdit)]
        public ActionResult<List<HotelAttachmentModel>> GetHotelAttachments(int fk_Hotel)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            return _unitOfWork.Hotel.GetHotelAttachments(new HotelAttachmentParameters { Fk_Hotel = fk_Hotel }, otherLang).ToList();
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.HotelAttachment, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Hotel.DeleteHotelAttachment(id);
            await _unitOfWork.Save();

            return NoContent();
        }

    }
}
