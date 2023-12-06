using AutoMapper;
using ZStore.Application.Api.Product;
using ZStore.Application.Api.Product.Queries;
using ZStore.Application.Api.Product.Queries.GetAllProductsPaged;
using ZStore.Application.Api.Product.Queries.GetProductById;
using ZStore.Application.Api.Product.Queries.GetProductsByCategory;
using ZStore.Domain.Models;

namespace ZStore.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            CreateMap<Product, ProductsViewModel>().ReverseMap();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            CreateMap<GetProductsByCategoryQuery, GetAllProductsParameter>();
            CreateMap<GetProductByIdQuery, GetAllProductsParameter>();
        }
    }
}
