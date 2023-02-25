using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olympiads.Core.Interfaces;

namespace Olympiads.DAL;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDAL(this IServiceCollection
        services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("EntityContext");
        services.AddDbContext<EntityDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
        services.AddScoped<IEntityDbContext>(provider =>
            provider.GetService<EntityDbContext>());

        return services;
    }
}