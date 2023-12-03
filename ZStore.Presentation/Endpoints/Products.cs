using MediatR;
using ZStore.Application.Api.Product;
using ZStore.Application.Api.Product.Queries;
using ZStore.Application.Api.Product.Queries.GetAllProductsPaged;
using ZStore.Application.Api.Product.Queries.GetProductById;
using ZStore.Application.Api.Product.Queries.GetProductsByCategory;
using ZStore.Domain.Utils;
using ZStore.Presentation.Infrastructure;

namespace ZStore.Presentation.Endpoints
{
    public class Products : EndpointGroupBase
    {
        public override void Map(WebApplication app)
        {
            app.MapGroup(this)
                .MapGet(GetAllProductsPaged)
                .MapGet(GetProductById, "{id}")
                .MapGet(GetAllProductsByCategory, "{category}");
        }

        public async Task<IResult> GetAllProductsPaged(ISender sender, [AsParameters] GetAllProductsQuery command)
        {
            return (IResult)await sender.Send(command);
        }
        public async Task<IResult> GetAllProductsByCategory(ISender sender, GetProductsByCategoryQuery command)
        {
            if (string.IsNullOrEmpty(command.CategoryName)) return Results.BadRequest();
            await sender.Send(command);
            return Results.NoContent();
        }

        public async Task<IResult> GetProductById(ISender sender, int id)
        {
            await sender.Send(new GetProductByIdQuery(id));
            return Results.NoContent();
        }
    }
}
