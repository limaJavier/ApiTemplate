using ApiTemplate.Api.Features.Items.Common;
using ApiTemplate.Application.Features.Items.Queries.Common;
using Mapster;

namespace ApiTemplate.Api.Utils.Mappings;

public class ItemMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ItemResult, ItemResponse>();
    }
}
