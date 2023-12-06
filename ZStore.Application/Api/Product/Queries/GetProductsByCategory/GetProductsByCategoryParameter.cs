using Application.Parameters;

namespace ZStore.Application.Api.Product.Queries.GetProductsByCategory
{
    public class GetProductsByCategoryParameter : RequestParameter
    {
        public string CategoryName { get; set; } = string.Empty;
    }
}
