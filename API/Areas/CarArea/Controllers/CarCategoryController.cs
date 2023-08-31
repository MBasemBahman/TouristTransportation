using API.Areas.CarArea.Models;
using Entities.CoreServicesModels.CarModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Areas.CarArea.Controllers
{
    [ApiVersion("1.0")]
    [Area("Car")]
    [ApiExplorerSettings(GroupName = "Car")]
    [Route("[area]/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    public class CarCategoryController : ExtendControllerBase
    {
        public CarCategoryController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetCarCategories))]
        public async Task<IEnumerable<CarCategoryDto>> GetCarCategories([FromQuery] CarCategoryParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<CarCategoryModel> accounts = await _unitOfWork.Car.GetCarCategoriesPaged(parameters, language);

            SetPagination(accounts.MetaData, parameters);

            List<CarCategoryDto> accountsDto = _mapper.Map<List<CarCategoryDto>>(accounts);

            return accountsDto;
        }

        [HttpGet]
        [Route(nameof(GetCarCategory))]
        public CarCategoryDto GetCarCategory([FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CarCategoryModel account = _unitOfWork.Car.GetCarCategoryById(id, language);

            CarCategoryDto accountDto = _mapper.Map<CarCategoryDto>(account);

            return accountDto;
        }
    }
}
