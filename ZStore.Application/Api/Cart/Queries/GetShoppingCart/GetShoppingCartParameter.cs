using Application.Parameters;
using ZStore.Application.Mappings;

namespace ZStore.Application.Api.Cart.Queries.GetShoppingCart
{
    public class GetShoppingCartParameter : RequestParameter, IMapFrom<GetShoppingCartQuery>
    {
        public string OwnerId { get; set; }
    }
}
