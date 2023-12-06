using AutoMapper;
using MediatR;
using ZStore.Application.Helpers;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Cart.Commands.AddItemToShoppingCart
{
    public partial class AddItemToShoppingCartCommand : IRequest<Response<int>>
    {
        public string OwnerId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
    }

    public class AddItemToShoppingCartCommandHandler : IRequestHandler<AddItemToShoppingCartCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedUserService _authenticatedUserService;

        public AddItemToShoppingCartCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAuthenticatedUserService authenticatedUserService)
        {
            _authenticatedUserService = authenticatedUserService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AddItemToShoppingCartCommand command, CancellationToken cancellationToken)
        {
            var userId = _authenticatedUserService.Id;

            // Ensure the user is authorized to modify this cart
            if (string.IsNullOrEmpty(userId) || userId != command.OwnerId)
                throw new UnauthorizedAccessException();

            // Retrieve or create the ShoppingCart
            var shoppingCart = await _unitOfWork.ShoppingCart.GetOrCreateCartAsync(userId);

            // Add the item to the cart
            shoppingCart.ProductIds.Add(command.ItemId);

            // Save changes
            await _unitOfWork.SaveAsync();

            return new Response<int>(command.ItemId);
        }
    }

}
