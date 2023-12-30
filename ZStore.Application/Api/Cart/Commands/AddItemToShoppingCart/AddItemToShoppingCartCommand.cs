using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using ZStore.Application.Exceptions;
using ZStore.Application.Helpers;
using ZStore.Application.Interfaces;
using ZStore.Domain.Models;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Cart.Commands.AddItemToShoppingCart
{
    [Authorize(Roles = SD.Role_User)]
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
        private readonly IUser _authenticatedUserService;

        public AddItemToShoppingCartCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUser authenticatedUserService)
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
                throw new ForbiddenAccessException();

            // Retrieve or create the ShoppingCart
            var shoppingCart = await _unitOfWork.ShoppingCart.GetOrCreateShoppingCartAsync(userId);

            var shoppingCartItem = new ShoppingCartItem
            {
                  ProductId = command.ItemId,
                  Quantity = command.Count,
                  ShoppingCartId = shoppingCart.Id,
            };

            // Add the item to the cart
            shoppingCart.ProductItems.Add(shoppingCartItem);

            // Save changes
            await _unitOfWork.SaveAsync();

            return new Response<int>(command.ItemId);
        }
    }

}
