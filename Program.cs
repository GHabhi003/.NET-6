using FinnHubAssignment;
using ServiceContract;
using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddControllers();
builder.Services.Configure<TradingOption>(builder.Configuration.GetSection("TradingOptions"));
builder.Services.AddSingleton<IFinnhubService, FinnhubService>();
builder.Services.AddSingleton<IStocksService, StocksService>();

var app = builder.Build();
app.MapControllers();
//app.MapGet("/", () => "Hello World!");

app.Run();
