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

            if (auth.Fk_Account == 0)
            {
                throw new Exception("Not Allowed");
            }

            PagedList<PostModel> posts = await _unitOfWork.Post.GetPostsPaged(parameters);

            SetPagination(posts.MetaData, parameters);

            List<PostDto> postsDto = _mapper.Map<List<PostDto>>(posts);

            postsDto.ForEach(post =>
            {
                post = SetAttachments(post).Result;
                if (post.OldPost != null && post.OldPost.AttachmentsCount > 0)
                {
                    post.OldPost = SetAttachments(post.OldPost).Result;
                }
            });

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

            //For My Reaction

            PostModel post = _unitOfWork.Post.GetPostById(id);

            PostDto postDto = _mapper.Map<PostDto>(post);

            postDto = await SetAttachments(postDto);

            if (postDto.OldPost != null && postDto.OldPost.AttachmentsCount > 0)
            {
                postDto.OldPost = SetAttachments(postDto.OldPost).Result;
            }

            return postDto;
        }

        [HttpPost]
        [Route(nameof(CreatePost))]
        public async Task<PostDto> CreatePost([FromForm] PostCreateOrEditDto model)
        {
            if (string.IsNullOrEmpty(model.Content))
            {
                throw new Exception("Please fill post content!");
            }
            
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

            
            PostModel postModel = _unitOfWork.Post.GetPostById(post.Id);
            PostDto returnData = _mapper.Map<PostDto>(postModel);

            returnData = await SetAttachments(returnData);

            if (returnData.OldPost != null && returnData.OldPost.AttachmentsCount > 0)
            {
                returnData.OldPost = SetAttachments(returnData.OldPost).Result;
            }

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

            if (string.IsNullOrEmpty(model.Content))
            {
                throw new Exception("Please fill post content!");
            }
            
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
            
            Post post = await _unitOfWork.Post.FindPostById(id, trackChanges: true);

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

            PostDto returnData = _mapper.Map<PostDto>(_unitOfWork.Post.GetPostById(id));

            returnData = await SetAttachments(returnData);

            if (returnData.OldPost is { AttachmentsCount: > 0 })
            {
                returnData.OldPost = SetAttachments(returnData.OldPost).Result;
            }

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
        
        // Helper Methods
        private async Task<PostDto> SetAttachments(PostDto post)
        {
            if (post.AttachmentsCount > 0 && post.Id > 0)
            {
                post.Attachments = _mapper.Map<IEnumerable<PostAttachmentDto>>(
                    await _unitOfWork.Post.GetPostAttachmentsPaged(new PostAttachmentParameters
                    {
                        Fk_Post = post.Id,
                        PageNumber = 1,
                        PageSize = 5,
                    }));
            }

            return post;
        }
    }
}
