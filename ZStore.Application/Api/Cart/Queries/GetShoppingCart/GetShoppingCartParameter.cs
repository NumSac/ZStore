using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Application.Mappings;

namespace ZStore.Application.Api.Cart.Queries.GetShoppingCart
{
    public class GetShoppingCartParameter : RequestParameter, IMapFrom<GetShoppingCartQuery>
    {
        public string OwnerId { get; set; }
    }
}
