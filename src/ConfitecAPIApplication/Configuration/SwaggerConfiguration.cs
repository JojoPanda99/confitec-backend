using System.Reflection;

namespace ConfitecAPIApplication.Configuration;

public static class SwaggerConfiguration
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new() { Title = "Confitec API", Version = "v1" }); });
    }

    public static void ConfigureSwagger(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Confitec API v1"));
    }
}