using AutoMapper;
using MediatR;
using ZStore.Application.Api.Product.Queries.GetAllProductsPaged;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Product.Queries.GetProductsByCategory
{
    public partial class GetProductsByCategoryQuery : IRequest<PagedResponse<IEnumerable<ProductsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string CategoryName { get; set; }
    }
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, PagedResponse<IEnumerable<ProductsViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsByCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ProductsViewModel>>> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllProductsParameter>(query);
            // Implement custom Linq query here for easy paging
            var products = await _unitOfWork.Product.GetProductsByCategoryAsync(query.CategoryName);
            var productViewModel = _mapper.Map<IEnumerable<ProductsViewModel>>(products);
            return new PagedResponse<IEnumerable<ProductsViewModel>>(productViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
