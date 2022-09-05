using Microsoft.AspNetCore.Rewrite;

namespace LMS.WebAPI.Configs;
public static class ApplicationConfigurations
{
    public static void ApplyConfiguration(this IApplicationBuilder builder)
    {
        builder.UseAuthentication();
        //builder.UseAuthorization();
        builder.UseRouting();
        builder.UseSwagger();
        builder.UseSwaggerUI();
        builder.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
        builder.UseCors("CorsPolicity");
        builder.UseHealthChecks("/healthapp");
    }
}