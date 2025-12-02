using ApiTemplate.Api;
using ApiTemplate.Application;
using ApiTemplate.Domain;
using ApiTemplate.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation();
    builder.Services.AddApplication();
    builder.Services.AddDomain();
    builder.Services.AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.AddPresentation();
    app.AddInfrastructure();
    app.Run();
}
