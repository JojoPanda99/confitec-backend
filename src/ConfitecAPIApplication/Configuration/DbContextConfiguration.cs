using ConfitecAPIData.Context;
using Microsoft.EntityFrameworkCore;

namespace ConfitecAPIApplication.Configuration;

public static class DbContextConfiguration
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ConfitecApiContext>(options => { options.UseSqlServer(connectionString); });
    }
}