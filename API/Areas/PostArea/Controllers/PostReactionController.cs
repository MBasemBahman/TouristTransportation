using API.Areas.PostArea.Models;
using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.PostModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.PostArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Post")]
    [ApiExplorerSettings(GroupName = "Post")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class PostReactionController : ExtendControllerBase
    {
        public PostReactionController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpPost]
        [Route(nameof(EditPostReaction))]
        public async Task<PostReactionDto> EditPostReaction([FromBody] PostReactioEditDto model)
        {
            UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            if (model.Fk_Post == 0)
            {
                throw new Exception("Bad Request!");
            }

            if(_unitOfWork.Post.GetPostReactions(new PostReactionParameters
            {
                Fk_Post =  model.Fk_Post,
                Fk_Account = auth.Fk_Account
            }, language: null).Any())
            {
                _unitOfWork.Post.DeletePostReaction(model.Fk_Post, auth.Fk_Account);
            }
            else
            {
                _unitOfWork.Post.CreatePostReaction(new PostReaction
                {
                    Fk_Account = auth.Fk_Account,
                    Fk_Post = model.Fk_Post,
                    Reaction = model.ReactionEnum
                });
            }
            await _unitOfWork.Save();

            PostReactionModel postReaction = _unitOfWork.Post.GetPostReactions(new PostReactionParameters
            {
                Fk_Post = model.Fk_Post,
                Fk_Account = auth.Fk_Account
            },language).FirstOrDefault();

            PostReactionDto returnData = _mapper.Map<PostReactionDto>(postReaction);
            return returnData;
        }

    }
}
