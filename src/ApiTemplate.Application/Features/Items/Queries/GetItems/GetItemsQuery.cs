using ApiTemplate.Application.Features.Items.Queries.Common;
using ApiTemplate.Domain.Common.Results;
using Mediator;

namespace ApiTemplate.Application.Features.Items.Queries.GetItems;

public record GetItemsQuery() : IQuery<Result<List<ItemResult>>>;
