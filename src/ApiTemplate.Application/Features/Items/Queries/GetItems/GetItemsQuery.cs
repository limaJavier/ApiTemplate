using ApiTemplate.Application.Features.Items.Queries.Common;
using ApiTemplate.Domain.Common.Results;
using Mediator;

namespace ApiTemplate.Application.Features.Items.Queries.GetItems;

public record GetItemsQuery(
    int Count
) : IQuery<Result<List<ItemResult>>>;
