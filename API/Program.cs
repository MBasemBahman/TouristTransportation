using API.Extensions;
using API.MappingProfileCls;
using API.Middlewares;
using NLog;

TenantConfig config = new(TenantEnvironments.Development);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), config.NlogConfig));

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile(config.AppSettings);

// Add services to the container
builder.Services.ConfigureCors();
builder.Services.AddHttpClient();
builder.Services.ConfigureLoggerService();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MappingProfile(provider.GetService<IOptions<AppSettings>>()));
}).CreateMapper());
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureLocalization();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureScopedService();  
builder.Services.ConfigureSqlContext(builder.Configuration, config);
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.ConfigureSwagger(config);
builder.Services.AddControllersWithViews(opt =>
{
    _ = opt.Filters.Add(typeof(GlobalModelStateValidatorAttribute));
});

WebApplication app = builder.Build();

ILoggerManager logger = app.Services.GetRequiredService<ILoggerManager>();
ILocalizationManager localizer = app.Services.GetRequiredService<ILocalizationManager>();

app.UseHttpsRedirection();
app.ConfigureStaticFiles();
app.UseFileServer();
app.UseCors();
app.ConfigureSwagger(config);
app.UseResponseCaching();
app.UseRequestLocalization(app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value);

app.UseMiddleware<BodyBufferingMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<CultureMiddleware>();
app.UseMiddleware<ThemeMiddleware>();
app.UseMiddleware<HeaderMiddleware>();
app.ConfigureExceptionHandler(logger);

app.UseRouting();
app.ConfigureStaticFiles();
app.UseFileServer();

app.MapControllers();

app.Run();
