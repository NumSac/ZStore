using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text;
using ZStore.Application.Api.Product.Queries.GetAllProductsPaged;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Product.Queries
{
    public class GetAllProductsQuery : IRequest<PagedResponse<IEnumerable<ProductsViewModel>>>
    {   
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductsQuery, PagedResponse<IEnumerable<ProductsViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<ProductsViewModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var validFilter = _mapper.Map<GetAllProductsParameter>(request);
            var product = await _unitOfWork.Product.GetPagedResponseAsync(request.PageNumber, request.PageSize);
            var productViewModel = _mapper.Map<IEnumerable<ProductsViewModel>>(product);
            return new PagedResponse<IEnumerable<ProductsViewModel>>(productViewModel, validFilter.PageNumber, validFilter.PageSize);
    }
    }

}
