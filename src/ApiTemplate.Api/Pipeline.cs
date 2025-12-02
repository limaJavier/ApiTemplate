using ApiTemplate.Api.Exceptions;
using FastEndpoints;
using FastEndpoints.Swagger;

namespace ApiTemplate.Api;

public static class Pipeline
{
    public static IApplicationBuilder AddPresentation(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(app => app.Run(GlobalExceptionHandler.Handle));
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseFastEndpoints()
            .UseSwaggerGen();
        return app;
    }
}
