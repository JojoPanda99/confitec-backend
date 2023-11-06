using ConfitecAPIBusiness.Interfaces;
using ConfitecAPIBusiness.Interfaces.Repositories;
using ConfitecAPIBusiness.Interfaces.Services;
using ConfitecAPIBusiness.Notifications;
using ConfitecAPIBusiness.Services;
using ConfitecAPIData.Repository;

namespace ConfitecAPIApplication.Configuration;

public static class DependencyInjectionConfiguration
{
    public static void ConfigureDependencyInjection(this IServiceCollection services)
    {
        //Repositories
        services.AddScoped<IUserRepository, UserRepository>();
        //Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<INotificationHandler, NotificationHandler>();
        //
    }
}