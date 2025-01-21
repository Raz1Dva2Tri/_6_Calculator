using OpenTelemetry.Metrics;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddOpenTelemetry()
    .WithMetrics(meterProviderBuilder =>
    {
        meterProviderBuilder.AddPrometheusExporter();

        // Добавляем метрики ASP.NET Core
        meterProviderBuilder.AddMeter("Microsoft.AspNetCore.Hosting",
                                      "Microsoft.AspNetCore.Server.Kestrel");

        // Добавляем метрику для HTTP-соединений
        meterProviderBuilder.AddMeter("Microsoft.AspNetCore.Http.Connections");

        // Настраиваем сбор метрик длительности запросов
        meterProviderBuilder.AddView("http.server.request.duration",
            new ExplicitBucketHistogramConfiguration
            {
                Boundaries = new double[]
                {
                    0, 0.005, 0.01, 0.025, 0.05, 0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10
                }
            });
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calculator}/{action=Index}/{id?}");

app.MapPrometheusScrapingEndpoint();

app.Run();
