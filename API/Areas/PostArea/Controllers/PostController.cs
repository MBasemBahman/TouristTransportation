using API.Areas.PostArea.Models;
using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.PostModels;

namespace API.Areas.PostArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Post")]
    [ApiExplorerSettings(GroupName = "Post")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    public class PostController : ExtendControllerBase
    {
        public PostController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {
            
        }

        [HttpGet]
        [Route(nameof(GetPosts))]
        public async Task<IEnumerable<PostDto>> GetPosts(
          [FromQuery] PostParameters parameters)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            parameters.Fk_AccountForReaction = auth.Fk_Account;
            parameters.IncludeAttachments = true;
            
            PagedList<PostModel> posts = await _unitOfWork.Post.GetPostsPaged(parameters);

            SetPagination(posts.MetaData, parameters);

            List<PostDto> postsDto = _mapper.Map<List<PostDto>>(posts);

            return postsDto;
        }

        [HttpGet]
        [Route(nameof(GetPost))]
        public async Task<PostDto> GetPost(
          [FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
            
            //For My Reaction

            PostModel post = _unitOfWork.Post.GetPosts(new PostParameters
            {
                Id = id,
                Fk_AccountForReaction = auth.Fk_Account,
                IncludeAttachments = true
            }).FirstOrDefault();

            PostDto postDto = _mapper.Map<PostDto>(post);

            return postDto;
        }

        [HttpPost]
        [Route(nameof(CreatePost))]
        public async Task<PostDto> CreatePost([FromForm] PostCreateOrEditDto model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            Post post = _mapper.Map<Post>(model);

            post.Fk_Account = auth.Fk_Account;

            post.CreatedBy = auth.UserName;

            if (model.AttachmentFiles != null && model.AttachmentFiles.Any())
            {
                post.PostAttachments = new List<PostAttachment>();

                foreach (IFormFile file in model.AttachmentFiles)
                {
                    post.PostAttachments.Add(new()
                    {
                        FileUrl = await _unitOfWork.Post.UploadPostAttachment(_environment.WebRootPath, file),
                        StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString()),
                        FileName = file.FileName,
                        FileLength = file.Length,
                        FileType = file.ContentType,
                    });
                }
            }
            
            _unitOfWork.Post.CreatePost(post);

            await _unitOfWork.Save();

            
            PostModel postModel = _unitOfWork.Post.GetPosts(new PostParameters
            {
                Id = post.Id,
                IncludeAttachments = true
            }).FirstOrDefault();
            
            PostDto returnData = _mapper.Map<PostDto>(postModel);
            
            return returnData;
        }

        [HttpPut]
        [Route(nameof(EditPost))]
        public async Task<PostDto> EditPost([FromQuery, BindRequired] int id, [FromForm] PostCreateOrEditDto model)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
            
            Post post = await _unitOfWork.Post.FindPostById(id, trackChanges: true);

            if (post.Fk_Account != auth.Fk_Account)
            {
                throw new Exception("Not Allowed");
            }
            
            model.Fk_Account = auth.Fk_Account;
            
            _ = _mapper.Map(model, post);

            post.LastModifiedBy = auth.UserName;

            if (model.AttachmentFiles != null && model.AttachmentFiles.Any())
            {
                post.PostAttachments = new List<PostAttachment>();

                foreach (IFormFile file in model.AttachmentFiles)
                {
                    PostAttachment attachment = new()
                    {
                        FileUrl = await _unitOfWork.Post.UploadPostAttachment(_environment.WebRootPath, file),
                        StorageUrl = _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(HttpContext.Request.RouteValues["area"].ToString()),
                        Fk_Post = post.Id,
                        FileName = file.FileName,
                        FileLength = file.Length,
                        FileType = file.ContentType,
                    };
                    _unitOfWork.Post.CreatePostAttachment(attachment);
                    
                    await _unitOfWork.Save();
                }
            }

            if (model.RmvAttachments != null && model.RmvAttachments.Any())
            {
                foreach (int attachmentId in model.RmvAttachments)
                {
                    await _unitOfWork.Post.DeletePostAttachment(attachmentId, post.Fk_Account, auth.Fk_Account);
                }
            }

            await _unitOfWork.Save();

            PostModel postModel = _unitOfWork.Post.GetPosts(new PostParameters
            {
                Id = id,
                Fk_AccountForReaction = auth.Fk_Account,
                IncludeAttachments = true
            }).FirstOrDefault();
            
            PostDto returnData = _mapper.Map<PostDto>(postModel);

            return returnData;
        }

        [HttpDelete]
        [Route(nameof(RemovePost))]
        public async Task<bool> RemovePost([FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            Post post = await _unitOfWork.Post.FindPostById(id, trackChanges: false);

            if (post.Fk_Account != auth.Fk_Account)
            {
                throw new Exception("Not Allowed");
            }

            _unitOfWork.Post.DeletePost(post);
            
            await _unitOfWork.Save();

            return true;
        }
        
    }
}
