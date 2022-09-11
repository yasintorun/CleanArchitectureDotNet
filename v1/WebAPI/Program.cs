using CleanArhitecture.Api.Configs;

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.RegisterServices(builder.Configuration);

    var app = builder.Build();
    app.ConfigureApplication();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    throw ex;
}

