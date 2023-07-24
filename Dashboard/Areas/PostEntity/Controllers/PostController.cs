using Contracts.Logger;
using Dashboard.Areas.PostEntity.Models;
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.PostModels;
using Entities.RequestFeatures;

namespace Dashboard.Areas.PostEntity.Controllers
{
    [Area("PostEntity")]
    [Authorize(DashboardViewEnum.Post, AccessLevelEnum.View)]
    public class PostController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;
        private readonly LinkGenerator _linkGenerator;
        private readonly IWebHostEnvironment _environment;


        public PostController(ILoggerManager logger, IMapper mapper,
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
            PostFilter filter = new()
            {
                Id = id,
            };

            ViewData["ProfileLayOut"] = ProfileLayOut;

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            SetViewData(id: 0);

            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] PostFilter dtParameters)
        {
            PostParameters parameters = new()
            {
                SearchColumns = "Id,Name"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<PostModel> data = await _unitOfWork.Post.GetPostsPaged(parameters);

            List<PostDto> resultDto = _mapper.Map<List<PostDto>>(data);

            DataTable<PostDto> dataTableManager = new();

            DataTableResult<PostDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.Post.GetPostsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }

        public IActionResult Details(int id)
        {
            PostDto data = _mapper.Map<PostDto>(_unitOfWork.Post
                                                           .GetPostById(id));

            return View(data);
        }

        [Authorize(DashboardViewEnum.Post, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            PostCreateOrEditModel model = new();

            if (id > 0)
            {
                Post dataDB = await _unitOfWork.Post.FindPostById(id, trackChanges: false);
                model = _mapper.Map<PostCreateOrEditModel>(dataDB);

                // model.PostBranches = _mapper.Map<List<PostBranchCreateOrEditModel>>(
                //     _unitOfWork.Post.GetPostBranches(new PostBranchParameters
                //     {
                //         Fk_Post = dataDB.Id,
                //     }).ToList());
            }

            SetViewData(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.Post, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEditWizard(int id, PostCreateOrEditModel model)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorMessages = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage).ToList();

                return BadRequest(errorMessages);
            }
            try
            {
                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items[ApiConstants.User];
                Post dataDB = new();
                if (id == 0)
                {
                    dataDB = _mapper.Map<Post>(model);

                    dataDB.CreatedBy = auth.UserName;

                    _unitOfWork.Post.AddPost(dataDB);
                }
                else
                {
                    dataDB = await _unitOfWork.Post.FindPostById(id, trackChanges: true);

                    _ = _mapper.Map(model, dataDB);

                    dataDB.LastModifiedBy = auth.UserName;
                }

                await _unitOfWork.Save();

                return Ok(new PostModel
                {
                    Id = dataDB.Id
                });
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            return BadRequest(new List<string>() { ViewData[ViewDataConstants.Error].ToString() });
        }

        [Authorize(DashboardViewEnum.Post, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            Post data = await _unitOfWork.Post.FindPostById(id, trackChanges: false);

            return View(data != null);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.Post, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Post.DeletePost(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        //helper method
        private void SetViewData(int id)
        {
            LanguageEnum? otherLang = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            ViewData["id"] = id;
            ViewData["Accounts"] = _unitOfWork.Account.GetAccountsLookUp(new AccountParameters(), otherLang);
        }

    }
}
