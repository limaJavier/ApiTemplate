using ApiTemplate.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.Api.Tests.ApiFactories;

public static class DependencyInjection
{
    public static void ConfigureDataAccess(this IServiceCollection services, string connectionString)
    {
        // Replace original DbContext registration
        var descriptor = services.SingleOrDefault(d =>
            d.ServiceType == typeof(DbContextOptions<ApiTemplateDbContext>))
            ?? throw new Exception($"Cannot resolve {nameof(ApiTemplateDbContext)} injection descriptor");

        services.Remove(descriptor);

        services.AddDbContext<ApiTemplateDbContext>((serviceProvider, options) =>
            options.UseNpgsql(connectionString)
        );
    }
}
