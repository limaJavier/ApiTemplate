using ApiTemplate.Application.Features.Items.Queries.Common;
using ApiTemplate.Domain.Common.Results;
using Mediator;

namespace ApiTemplate.Application.Features.Items.Queries.GetItems;

public class GetItemsQueryHandler : IQueryHandler<GetItemsQuery, Result<List<ItemResult>>>
{
    public async ValueTask<Result<List<ItemResult>>> Handle(GetItemsQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var items = new List<ItemResult>
        {
            new("Item 1", "Description 1"),
            new("Item 2", "Description 2"),
            new("Item 3", "Description 3"),
            new("Item 4", "Description 4"),
            new("Item 5", "Description 5"),
            new("Item 6", "Description 6"),
            new("Item 7", "Description 7"),
            new("Item 8", "Description 8"),
            new("Item 9", "Description 9"),
            new("Item 10", "Description 10"),
        };

        return items.Take(query.Count).ToList();
    }
}
