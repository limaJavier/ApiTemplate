using System.Net;
using ApiTemplate.Api.Features.Items.Common;
using ApiTemplate.Api.Tests.Features.Common;
using ApiTemplate.Api.Tests.Features.Utils;
using ApiTemplate.Api.Tests.Fixtures;
using Xunit.Abstractions;

namespace ApiTemplate.Api.Tests.Features.Items;

public class GetItemsTests(ITestOutputHelper output, PostgresContainerFixture postgresContainerFixture) : IsolatedTests(output, postgresContainerFixture)
{
    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(10)]
    public async Task WhenCountIsValid_ShouldReturnItems(int count)
    {
        //** Arrange and Act
        var response = await _client.SendAsync<List<ItemResponse>>(
            method: HttpMethod.Get,
            route: $"/items?{nameof(count)}={count}"
        );

        foreach (var item in response)
            _output.WriteLine(item.Name);

        //** Assert
        Assert.NotEmpty(response);
        Assert.Equal(count, response.Count);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    [InlineData(11)]
    [InlineData(100)]
    public async Task WhenCountIsOutOfRange_ShouldReturnBadRequest(int count)
    {
        //** Arrange and Act
        var httpResponse = await _client.SendAsync(
            method: HttpMethod.Get,
            route: $"/items?{nameof(count)}={count}"
        );

        //** Assert
        Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
    }
}
