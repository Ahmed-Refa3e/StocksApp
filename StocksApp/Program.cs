using Services;
using StocksApp;

var builder = WebApplication.CreateBuilder(args);
//services
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<Finhubservice>();
builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
