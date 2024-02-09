using AutoMapper;
using ZStore.Application.Mappings;
using ZStore.Domain.Models;

namespace ZStore.Application.Api.Cart
{
    public class ShoppingCartViewModel : IMapFrom<ShoppingCart>
    {
        public ICollection<ShoppingCartItem> ProductItems { get; set; }
        public double Price { get; set; }
    }
}
