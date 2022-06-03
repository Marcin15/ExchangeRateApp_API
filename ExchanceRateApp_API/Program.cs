using ExchangeRateApp_API.ExceptionHandlers;
using ExchangeRateApp_API.Interfaces;
using ExchangeRateApp_API.Middleware;
using ExchangeRateApp_API.Services;
using NLog;
using NLog.Web;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "ExchangeRateApp API",
        Description = "Server side application for ExchangeRateApp"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    config.IncludeXmlComments(xmlPath);
});

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddCors(p => p.AddPolicy("corsapp", policybuilder =>
{
    policybuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddTransient<IOuterWebApiDataReceiveService, OuterWebApiDataReceiveService>();
builder.Services.AddSingleton<ICurrencySymbolsFileReadService, CurrencySymbolsFileReadService>();
builder.Services.AddTransient<IHistoricalCurrencyService, HistoricalCurrencyService>();
builder.Services.AddTransient<ILatestCurrencyService, LatestCurrencyService>();
builder.Services.AddSingleton<IHttpClientManager, HttpClientManager>();
builder.Services.AddSingleton<IHistoricalCurrencyDtoToModelMapService, HistoricalCurrencyDtoToModelMapService>();
builder.Services.AddSingleton<IStringArrayToStringMapService, StringArrayToStringMapService>();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IArgumentNullExceptionHandler, ArgumentNullExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
    
app.Run();
