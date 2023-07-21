using Contracts.Logger;
using Dashboard.Areas.AccountEntity.Models;
using Dashboard.Areas.PostEntity.Models;
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.PostModels;
using Entities.EnumData;
using Entities.RequestFeatures;

namespace Dashboard.Areas.PostEntity.Controllers
{
    [Area("PostEntity")]
    [Authorize(DashboardViewEnum.PostReaction, AccessLevelEnum.View)]
    public class PostReactionController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public PostReactionController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork, LinkGenerator linkGenerator,
                IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
        }

        public IActionResult Index(int id, bool ProfileLayOut = false)
        {

            PostReactionFilter filter = new()
            {
                Id = id
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] PostReactionFilter dtParameters)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PostReactionParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<PostReactionModel> data = await _unitOfWork.Post.GetPostReactionsPaged(parameters, otherLang);

            List<PostReactionDto> resultDto = _mapper.Map<List<PostReactionDto>>(data);

            DataTable<PostReactionDto> dataTableManager = new();

            DataTableResult<PostReactionDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Post.GetPostReactionsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            LanguageEnum otherLang = (LanguageEnum)Request.HttpContext.Items[ApiConstants.Language];

            PostReactionDto data = _mapper.Map<PostReactionDto>(_unitOfWork.Post.GetPostReactionById(id, otherLang));

            return View(data);
        }
        
        [Authorize(DashboardViewEnum.PostReaction, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            PostReaction data = await _unitOfWork.Post.FindPostReactionById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.PostReaction, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Post.DeletePostReaction(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            ViewData["id"] = id;
        }

    }
}
