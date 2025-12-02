using ApiTemplate.Application.Common.Interfaces;
using ApiTemplate.Infrastructure.Persistence;
using ApiTemplate.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add dbContext
        var connectionString = configuration.GetConnectionString(nameof(ApiTemplate));
        services.AddDbContext<ApiTemplateDbContext>(options =>
            options.UseNpgsql(connectionString));

        // Add services
        services.AddScoped<IUnitOfWork>(serviceProvider => 
            serviceProvider.GetRequiredService<ApiTemplateDbContext>());

        services.AddScoped<IApplicationEventQueue, ApplicationEventQueue>();

        return services;
    }
}
