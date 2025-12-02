using ApiTemplate.Infrastructure.Middlewares;
using ApiTemplate.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.Infrastructure;

public static class Pipeline
{
    public static IApplicationBuilder AddInfrastructure(this IApplicationBuilder app)
    {
        app.UseMiddleware<EventualConsistencyMiddleware>();
        app.ApplyMigrations();
        return app;
    }

    private static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<ApiTemplateDbContext>();
        dbContext.Database.Migrate();
    }
}
