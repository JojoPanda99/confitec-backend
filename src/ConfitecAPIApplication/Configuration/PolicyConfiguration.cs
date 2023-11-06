namespace ConfitecAPIApplication.Configuration;

public static class PolicyConfiguration
{
    public static void ConfigurePolicies(this IServiceCollection services)
    {
        services.AddCors();
    }

    public static void UsePolicies(this IApplicationBuilder app)
    {
        var origin = "http://localhost:4200" ;
        app.UseCors(builder => builder.WithOrigins(origin).AllowAnyHeader().AllowAnyMethod().AllowCredentials());
    }
}