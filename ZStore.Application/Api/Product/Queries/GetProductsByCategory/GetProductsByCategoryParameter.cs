using Application.Parameters;
using ZStore.Application.Mappings;

namespace ZStore.Application.Api.Product.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryParameter : RequestParameter, IMapFrom<GetProductsByCategoryQuery>
    {
        public string CategoryName { get; set; } = string.Empty;
    }
}
