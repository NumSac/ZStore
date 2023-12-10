using AutoMapper;
using ZStore.Application.Mappings;

namespace ZStore.Application.Api.Product
{
    public class ProductsViewModel : IMapFrom<ZStore.Domain.Models.Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
}
