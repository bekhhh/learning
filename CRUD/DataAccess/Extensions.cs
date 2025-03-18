using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddDbContext<AppContex>(x =>
        {
            x.UseNpgsql("Host=localhost;Database=UserDb;Username=postgres;Password=forever7277database");
        });
        
        return serviceCollection;
    }
}