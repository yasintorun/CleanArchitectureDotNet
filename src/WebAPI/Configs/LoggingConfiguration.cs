using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;

namespace Kod.WebAPI.Configs;
public static class LoggingConfiguration
{
    public static void ConfigureLogging(this ILoggingBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                optional: true)
            .Build();

        var logProp = ConfigureElasticSink(configuration);

        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithMachineName()
            .WriteTo.Debug()
            .WriteTo.Console(outputTemplate: "[{CorrelationId}\t{Level}\t{SourceContext}]{NewLine}{Message:j}{NewLine}{Properties}{NewLine}{Exception}{NewLine}" +
                "------------------------------------------------------------------------------------------{NewLine}")
            .WriteTo.Elasticsearch(logProp)
            .WriteTo.Console(new ElasticsearchJsonFormatter())
            .Enrich.FromLogContext()
            .Enrich.WithProperty("Environment", environment)
            .ReadFrom.Configuration(configuration)
            .CreateLogger();

        builder.ClearProviders();
        builder.AddSerilog(logger);
    }

    private static ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration)
    {
        var uri = new Uri(configuration["ElasticConfiguration:Uri"]);

        return new ElasticsearchSinkOptions(uri)
        {
            AutoRegisterTemplate = true,
            AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6,
            IndexFormat = $"{configuration["ElasticConfiguration:IndexName"]}_{DateTime.UtcNow:yyyy-MM}"
        };
    }
}
