﻿namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class ExtendControllerBase : ControllerBase
    {
        protected readonly ILoggerManager _logger;
        protected readonly IMapper _mapper;
        protected readonly LinkGenerator _linkGenerator;
        protected readonly UnitOfWork _unitOfWork;
        protected readonly IWebHostEnvironment _environment;
        protected readonly AppSettings _appSettings;
        protected TenantEnvironments _tenantEnvironment;

        public ExtendControllerBase(
        ILoggerManager logger,
        IMapper mapper,
        UnitOfWork unitOfWork,
        LinkGenerator linkGenerator,
        IWebHostEnvironment environment,
         IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _linkGenerator = linkGenerator;
            _environment = environment;
            _appSettings = appSettings.Value;
            SetTenantEnvironment();
        }

        // Helper Methods
        protected void SetPagination(MetaData metaData, RequestParameters requestParameters)
        {
            string actionUri = _linkGenerator.GetUriByAction(HttpContext);

            Response.Headers.Add(key: HeadersConstants.Pagination, value: ReplaceCommna(MetaData.PaginationMetaData(metaData, requestParameters, actionUri)));
        }

        protected string GetBaseUri()
        {
            var areaVal = HttpContext.Request.RouteValues["area"];
            string area = HttpContext.Request.RouteValues["area"].ToString();
            return _linkGenerator.GetUriByAction(HttpContext).GetBaseUri(area);
        }

        protected void SetToken(TokenResponse token)
        {
            Response.Headers.Add(key: HeadersConstants.Expires, value: ReplaceCommna(token.Expires));
            Response.Headers.Add(key: HeadersConstants.Authorization, value: ReplaceCommna(token.RefreshToken));
        }

        protected void SetRefresh(TokenResponse token)
        {
            Response.Headers.Add(key: HeadersConstants.SetRefresh, value: token.ToString());
        }

        protected string IpAddress()
        {
            // get source ip address for the current request
            return Request.Headers.ContainsKey("x-Forwarded-For")
                ? (string)Request.Headers["x-Forwarded-For"]
                : HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        private void SetTenantEnvironment()
        {
            foreach (TenantEnvironments item in (TenantEnvironments[])Enum.GetValues(typeof(TenantEnvironments)))
            {
                if (_appSettings.TenantEnvironment.ToUpper() == item.ToString())
                {
                    _tenantEnvironment = item;
                    break;
                }
            }
        }

        protected static string ReplaceCommna(string data)
        {
            return data.Replace(",", @"\002C");
        }
    }
}
