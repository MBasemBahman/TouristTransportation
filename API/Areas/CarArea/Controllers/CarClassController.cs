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
    public class CarClassController : ExtendControllerBase
    {
        public CarClassController(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
        IOptions<AppSettings> appSettings) : base(logger, mapper, unitOfWork, linkGenerator, environment, appSettings)
        {

        }

        [HttpGet]
        [Route(nameof(GetCarClasses))]
        public async Task<IEnumerable<CarClassDto>> GetCarClasses([FromQuery] CarClassParameters parameters)
        {
            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            PagedList<CarClassModel> accounts = await _unitOfWork.Car.GetCarClassesPaged(parameters, language);

            SetPagination(accounts.MetaData, parameters);

            List<CarClassDto> accountsDto = _mapper.Map<List<CarClassDto>>(accounts);

            return accountsDto;
        }

        [HttpGet]
        [Route(nameof(GetCarClass))]
        public CarClassDto GetCarClass([FromQuery, BindRequired] int id)
        {
            if (id == 0)
            {
                throw new Exception("Bad Request!");
            }

            LanguageEnum? language = (LanguageEnum?)Request.HttpContext.Items[ApiConstants.Language];

            CarClassModel account = _unitOfWork.Car.GetCarClassById(id, language);

            CarClassDto accountDto = _mapper.Map<CarClassDto>(account);

            return accountDto;
        }
    }
}
