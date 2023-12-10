using AutoMapper;
using MediatR;
using ZStore.Application.Exceptions;
using ZStore.Application.Helpers;
using ZStore.Application.Interfaces;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Cart.Queries.GetShoppingCart
{
    public partial class GetShoppingCartQuery : IRequest<PagedResponse<ShoppingCartViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OwnerId { get; set; }
    }
    public class GetShoppingCartQueryHandler : IRequestHandler<GetShoppingCartQuery, PagedResponse<ShoppingCartViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUser _authenticatedUserService;

        public GetShoppingCartQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IUser authenticatedUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authenticatedUserService = authenticatedUserService;
        }

        public async Task<PagedResponse<ShoppingCartViewModel>> Handle(GetShoppingCartQuery query, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetShoppingCartParameter>(query);
            var userId = _authenticatedUserService.Id;
            Console.WriteLine("Reached line 34 in GetShoppingCartQuery");
            if (string.IsNullOrEmpty(userId) || userId != query.OwnerId)
                throw new ForbiddenAccessException();

            var shoppingCart = await _unitOfWork.ShoppingCart.GetAsync(x => x.ApplicationUserId == userId);
            if (shoppingCart == null)
            {
                _unitOfWork.ShoppingCart.Add(new Domain.Models.ShoppingCart
                {
                    ApplicationUserId = userId,
                });

                await _unitOfWork.SaveAsync();
            }

            var mappedShoppingCart = _mapper.Map<ShoppingCartViewModel>(query);

            return new PagedResponse<ShoppingCartViewModel>(mappedShoppingCart, query.PageNumber, query.PageSize);
        }
    }
}
