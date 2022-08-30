using Kod.WebAPI.Configs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices(builder.Configuration);

builder.Logging.ConfigureLogging();

var app = builder.Build();

app.ApplyConfiguration();

app.MapControllers();

app.Run();
    