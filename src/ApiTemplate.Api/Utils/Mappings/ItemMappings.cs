using ApiTemplate.Api.Features.Items.Common;
using ApiTemplate.Api.Features.Items.GetItems;
using ApiTemplate.Application.Features.Items.Queries.Common;
using ApiTemplate.Application.Features.Items.Queries.GetItems;
using Mapster;

namespace ApiTemplate.Api.Utils.Mappings;

public class ItemMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {        
        config.NewConfig<GetItemsRequest, GetItemsQuery>();
        config.NewConfig<ItemResult, ItemResponse>();
    }
}
