using ApiTemplate.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace ApiTemplate.Api.Tests.Features.Common.Flows;

public abstract class AbstractFlows(IServiceProvider serviceProvider, HttpClient client)
{
    protected readonly IServiceProvider _serviceProvider = serviceProvider;
    protected readonly HttpClient _client = client;
    protected ApiTemplateDbContext ResolveDbContext()
    {
        return _serviceProvider.GetRequiredService<ApiTemplateDbContext>();
    }
}
