using Microsoft.AspNetCore.Rewrite;

namespace CleanArhitecture.Api.Configs
{
    public static class ApplicationConfiguration
    {
        public static void ConfigureApplication(this IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            app.UseHealthChecks("/healthcheck");
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
