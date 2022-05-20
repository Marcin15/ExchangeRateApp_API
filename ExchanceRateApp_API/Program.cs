using ExchanceRateApp_API.Interfaces;
using ExchanceRateApp_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corsapp", policybuilder =>
{
    policybuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddTransient<IOuterWebApiDataReceiveService, OuterWebApiDataReceiveService>();
builder.Services.AddSingleton<ICurrencySymbolsFileReadService, CurrencySymbolsFileReadService>();
builder.Services.AddTransient<IHistoricalCurrencyService, HistoricalCurrencyService>();
builder.Services.AddTransient<ILatestCurrencyService, LatestCurrencyService>();
builder.Services.AddSingleton<IHttpClientManager, HttpClientManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
    
app.Run();
