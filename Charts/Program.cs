using Charts.Hubs;
using Charts.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Services.AddSingleton(_ => {
    var buffer = new Buffer<Point>(10);
    
    for (var i = 0; i < 7; i++) 
        buffer.AddNewRandomPoint();

    return buffer;
});

builder.Services.AddHostedService<ChartValueGenerator>();

var app = builder.Build();

app.UseStaticFiles();
app.MapRazorPages();
app.MapHub<ChartHub>(ChartHub.Url);

app.Run();