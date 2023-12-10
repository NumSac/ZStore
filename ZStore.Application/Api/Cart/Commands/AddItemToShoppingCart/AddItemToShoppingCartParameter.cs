using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZStore.Application.Api.Cart.Commands.AddItemToShoppingCart
{
    public class AddItemToShoppingCartParameter
    {
        public int ItemId { get; set; }
        public int ItemCount { get; set; }
        public string OwnerId { get; set; }
    }
}
