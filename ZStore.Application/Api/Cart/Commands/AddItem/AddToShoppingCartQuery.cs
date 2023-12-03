using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZStore.Application.Api.Cart.Commands.AddItem
{
    public class AddToShoppingCartQuery
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
