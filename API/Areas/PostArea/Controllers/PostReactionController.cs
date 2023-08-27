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

        //[HttpPost]
        //[Route(nameof(CreatePost))]
        //public async Task<PostDto> CreatePost([FromForm] PostCreateOrEditDto model)
        //{
        //    UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];

            

        //    return returnData;
        //}

    }
}
