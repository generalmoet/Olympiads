using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Olympiads.Core.Interfaces;
using Olympiads.DAL.Authentication;

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
        });
        services.AddScoped<IEntityDbContext>(provider =>
            provider.GetService<EntityDbContext>());

        services.AddTransient<JwtOptions>();
        services.AddScoped<IJwtProvider, JwtProvider>();

        return services;
    }
}