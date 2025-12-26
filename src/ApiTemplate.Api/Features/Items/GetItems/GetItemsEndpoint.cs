using ApiTemplate.Api.Exceptions;
using ApiTemplate.Api.Features.Items.Common;
using ApiTemplate.Application.Features.Items.Queries.GetItems;
using FastEndpoints;
using Mediator;

namespace ApiTemplate.Api.Features.Items.GetItems;

public class GetItemsEndpoint(
    ISender sender,
    IMapper mapper
) : Endpoint<GetItemsRequest, List<ItemResponse>>
{
    private readonly ISender _sender = sender;
    private readonly IMapper _mapper = mapper;

    public override void Configure()
    {
        Get("/items");
        AllowAnonymous();
    }

    public override async Task<List<ItemResponse>> ExecuteAsync(GetItemsRequest request, CancellationToken ct)
    {
        var query = _mapper.Map<GetItemsQuery>(request);
        var result = await _sender.Send(query);
        if (result.IsFailure)
            throw ApiException.FromError(result.Error);

        var response = result.Value.Select(_mapper.Map<ItemResponse>).ToList();
        return response;
    }
}
