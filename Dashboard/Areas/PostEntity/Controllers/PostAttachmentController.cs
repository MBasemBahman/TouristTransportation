using Contracts.Logger;
using Dashboard.Areas.PostEntity.Models;
using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.PostModels;
using Entities.RequestFeatures;

namespace Dashboard.Areas.PostEntity.Controllers
{
    [Area("PostEntity")]
    [Authorize(DashboardViewEnum.PostAttachment, AccessLevelEnum.View)]
    public class PostAttachmentController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public PostAttachmentController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }

        [Authorize(DashboardViewEnum.PostAttachment, AccessLevelEnum.Create)]
        public async Task<IActionResult> Upload(int fk_Post)
        {
            IFormFile file = HttpContext.Request.Form.Files["file"];
            if (file != null)
            {
                PostAttachment attachment = new()
                {
                    FileUrl = await _unitOfWork.Post.UploadPostAttachment(_environment.WebRootPath, file),
                    StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString()),
                    Fk_Post = fk_Post,
                    FileName = file.FileName,
                    FileLength = file.Length,
                    FileType = file.ContentType,
                };
                _unitOfWork.Post.CreatePostAttachment(attachment);
                await _unitOfWork.Save();
            }
            
            return NoContent();
        }

        [Authorize(DashboardViewEnum.PostAttachment, AccessLevelEnum.CreateOrEdit)]
        public ActionResult<List<PostAttachmentModel>> GetPostAttachments(int fk_Post)
        {
            return _unitOfWork.Post.GetPostAttachments(new PostAttachmentParameters { Fk_Post = fk_Post }).ToList();
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.PostAttachment, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Post.DeletePostAttachment(id);
            await _unitOfWork.Save();

            return NoContent();
        }

    }
}
