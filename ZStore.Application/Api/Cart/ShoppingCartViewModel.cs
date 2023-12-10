using AutoMapper;
using ZStore.Application.Mappings;
using ZStore.Domain.Models;

namespace ZStore.Application.Api.Cart
{
    public class ShoppingCartViewModel : IMapFrom<ShoppingCart>
    {
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public double TotalPrice { get; set; }
        public string UserId { get; set; }
    }
}
