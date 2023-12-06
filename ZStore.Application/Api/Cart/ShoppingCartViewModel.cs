using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Domain.Models;

namespace ZStore.Application.Api.Cart
{
    public class ShoppingCartViewModel
    {
        public ICollection<int> CartItemIds { get; set; }
        public double TotalPrice { get; set; }
        public string UserId { get; set; }

        private class Mapping : Profile
        {
            public Mapping() 
            {
                CreateMap<ShoppingCart, ShoppingCartViewModel>();
            }
        }
    }
}
