using Contracts.Logger;
using Dashboard.Areas.DashboardAdministration.Models;
using Entities.DBModels.DashboardAdministrationModels;
using Entities.RequestFeatures;
namespace Dashboard.Areas.DashboardAdministration.Controllers
{
    [Area("DashboardAdministration")]
    [Authorize(DashboardViewEnum.DashboardView, AccessLevelEnum.View)]
    public class DashboardViewController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _unitOfWork;

        public DashboardViewController(ILoggerManager logger, IMapper mapper,
                UnitOfWork unitOfWork)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index(int id)
        {
            DashboardViewFilter filter = new()
            {
                Id = id
            };

            ViewData[ViewDataConstants.AccessLevel] = (DashboardAccessLevelModel)Request.HttpContext.Items[ViewDataConstants.AccessLevel];

            return View(filter);
        }
        [HttpPost]
        public async Task<IActionResult> LoadTable([FromBody] DashboardViewFilter dtParameters)
        {
            DashboardViewParameters parameters = new()
            {
                SearchColumns = "Id,Name,ViewPath"
            };

            _ = _mapper.Map(dtParameters, parameters);

            PagedList<DashboardViewModel> data = await _unitOfWork.DashboardAdministration.GetViewsPaged(parameters);

            List<DashboardViewDto> resultDto = _mapper.Map<List<DashboardViewDto>>(data);

            DataTable<DashboardViewDto> dataTableManager = new();

            DataTableResult<DashboardViewDto> dataTableResult = dataTableManager.LoadTable(dtParameters, resultDto, data.MetaData.TotalCount, _unitOfWork.DashboardAdministration.GetViewsCount());

            return Json(dataTableManager.ReturnTable(dataTableResult));
        }


        public IActionResult Details(int id)
        {
            DashboardViewDto data = _mapper.Map<DashboardViewDto>(_unitOfWork.DashboardAdministration
                                                            .GetViewbyId(id));

            return View(data);
        }

        [Authorize(DashboardViewEnum.DashboardView, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id = 0)
        {
            DashboardViewCreateOrEditModel model = new();

            if (id > 0)
            {
                model = _mapper.Map<DashboardViewCreateOrEditModel>(
                                                await _unitOfWork.DashboardAdministration.FindViewById(id, trackChanges: false));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(DashboardViewEnum.DashboardView, AccessLevelEnum.CreateOrEdit)]
        public async Task<IActionResult> CreateOrEdit(int id, DashboardViewCreateOrEditModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                DashboardView dataDb = new();
                if (id == 0)
                {

                    dataDb = _mapper.Map<DashboardView>(model);
                    _unitOfWork.DashboardAdministration.CreateView(dataDb);
                }
                else
                {
                    dataDb = await _unitOfWork.DashboardAdministration.FindViewById(id, trackChanges: true);
                    _ = _mapper.Map(model, dataDb);
                }

                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            return View(model);
        }

        [Authorize(DashboardViewEnum.DashboardView, AccessLevelEnum.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            DashboardView data = await _unitOfWork.DashboardAdministration.FindViewById(id, trackChanges: false);

            return View(data != null && !_unitOfWork.DashboardAdministration.GetPremissions(new AdministrationRolePremissionParameters { Fk_DashboardView = id }, language: null).Any());
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(DashboardViewEnum.DashboardView, AccessLevelEnum.Delete)]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.DashboardAdministration.DeleteView(id);
            await _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}
