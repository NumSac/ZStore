using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZStore.Application.Api.Cart.Queries.GetShoppingCart
{
    public class GetShoppingCartParameter : RequestParameter
    {
        public string CartOwnerId { get; set; } = string.Empty;
    }
}
