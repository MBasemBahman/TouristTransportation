using API.Areas.PostArea.Models;
using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.PostModels;

namespace API.Areas.PostArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Post")]
    [ApiExplorerSettings(GroupName = "Post")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class PostAttachmentController : ExtendControllerBase
    {
        public PostAttachmentController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        { }

        [HttpGet]
        [Route(nameof(GetPostAttachments))]
        public async Task<IEnumerable<PostAttachmentDto>> GetPostAttachments(
        [FromQuery] PostAttachmentParameters parameters)
        {
            if (parameters.Fk_Post == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            Post post = await _unitOfWork.Post.FindPostById(parameters.Fk_Post, trackChanges: false);
            
            if (post.Fk_Account != auth.Fk_Account)
            {
                throw new Exception("Not Allowed");
            }

            
            PagedList<PostAttachmentModel> attachments = await _unitOfWork.Post.GetPostAttachmentsPaged(parameters);

            SetPagination(attachments.MetaData, parameters);

            IEnumerable<PostAttachmentDto> attachmentsDto = _mapper.Map<IEnumerable<PostAttachmentDto>>(attachments);

            return attachmentsDto;
        }

        [HttpPost]
        [Route(nameof(CreatePostAttachments))]
        public async Task<bool> CreatePostAttachments(
          [FromQuery, BindRequired] int fk_post,
          [FromForm] List<IFormFile> files)
        {
            if (fk_post == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            Post post = await _unitOfWork.Post.FindPostById(fk_post, trackChanges: false);
            
            if (post.Fk_Account != auth.Fk_Account)
            {
                throw new Exception("Not Allowed");
            }

            if (files != null && files.Any())
            {
                foreach (IFormFile file in files)
                {
                    PostAttachment attachment = new()
                    {
                        FileUrl = await _unitOfWork.Post.UploadPostAttachment(_environment.WebRootPath, file),
                        StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString()),
                        Fk_Post = fk_post,
                        FileName = file.FileName,
                        FileLength = file.Length,
                        FileType = file.ContentType,
                    };
                    
                    _unitOfWork.Post.CreatePostAttachment(attachment);
                    await _unitOfWork.Save();
                }

                await _unitOfWork.Save();
            }

            return true;
        }
    }
}
