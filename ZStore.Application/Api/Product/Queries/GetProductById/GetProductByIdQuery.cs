using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZStore.Application.Api.Product.Queries.GetAllProductsPaged;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<ProductsViewModel>>
    {
        public int Id { get; set; }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<ProductsViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<ProductsViewModel>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Product.GetByIdAsync(query.Id);
            if (product == null) throw new Exception($"Product Not Found");
            var productViewModel = _mapper.Map<ProductsViewModel>(product);
            return new Response<ProductsViewModel>(productViewModel);
        }
    }
}
