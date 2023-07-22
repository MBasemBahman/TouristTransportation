using DevelopmentDAL;
using Entities.ServicesModels;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {

            _ = services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    _ = builder.SetIsOriginAllowed(a => true)
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials()
                           .WithExposedHeaders(HeadersConstants.Status,
                                               HeadersConstants.Pagination,
                                               HeadersConstants.Authorization,
                                               HeadersConstants.Expires,
                                               HeadersConstants.SetRefresh);
                });
            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            _ = services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            _ = services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            _ = services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureScopedService(this IServiceCollection services)
        {
            _ = services.AddScoped<IJwtUtils, JwtUtils>();
            _ = services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            _ = services.AddScoped<ServicesHttpClient, ServicesHttpClient>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration,
            TenantConfig config)
        {
            if (config.Tenant == TenantEnvironments.Development)
            {
                _ = services.AddDbContext<BaseContext, DevelopmentContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                                                                options => options.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

                _ = services.AddScoped(_ =>
                {
                    HttpContext httpContext = new HttpContextAccessor().HttpContext;

                    return new UserAuthenticatedDto
                    {
                    };
                });
            }
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            _ = services.AddScoped<RepositoryManager>();
            _ = services.AddScoped<UnitOfWork>();
        }

        public static void ConfigureVersioning(this IServiceCollection services)
        {
            _ = services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            _ = services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
        }

        public static void ConfigureResponseCaching(this IServiceCollection services)
        {
            _ = services.AddResponseCaching();
        }

        public static void ConfigureSwagger(this IServiceCollection services, TenantConfig config)
        {
            _ = services.AddSwaggerGen(c =>
            {
                c.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("hh:mm:ss")
                });

                c.MapType<DateTime>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("yyyy-MM-ddThh:mm:ss")
                });

                foreach (SwaggerModel page in config.SwaggerPages)
                {
                    c.SwaggerDoc(page.Name, new OpenApiInfo { Title = page.Title });
                }

                c.OperationFilter<DocsFilter>();

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public static void ConfigureLocalization(this IServiceCollection services)
        {
            _ = services.AddLocalization(options => options.ResourcesPath = "Resources");

            _ = services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo> {new CultureInfo("ar")};
            
                foreach (string language in Enum.GetNames(typeof(LanguageEnum)))
                {
                    supportedCultures.Add(new CultureInfo(language));
                }
                
                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            _ = services.AddSingleton<ILocalizationManager, LocalizationManager>();
        }
    }
}
