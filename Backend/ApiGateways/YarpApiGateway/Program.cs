using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.PermitLimit = 5;
        opt.Window = TimeSpan.FromSeconds(10);
        //opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        //opt.QueueLimit = 2;
    });
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.UseRateLimiter();
app.MapReverseProxy();

app.Run();
