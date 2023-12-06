using AutoMapper;

namespace ZStore.Application.Api.Product
{
    public class ProductsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }

        private class Mapping : Profile
        {
            public Mapping() 
            {
                CreateMap<Domain.Models.Product, ProductsViewModel>();
            }
        }
    }
}
