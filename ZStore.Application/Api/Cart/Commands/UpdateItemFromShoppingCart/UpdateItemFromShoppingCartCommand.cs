using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using ZStore.Application.Exceptions;
using ZStore.Application.Helpers;
using ZStore.Application.Interfaces;
using ZStore.Domain.Utils;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Cart.Commands.RemoveItemFromShoppingCart
{
    public partial class UpdateItemFromShoppingCartCommand : IRequest<Response<int>>
    {
        public string OwnerId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
    }

    public class UpdateItemFromShoppingCartCommandHandler : IRequestHandler<UpdateItemFromShoppingCartCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateItemFromShoppingCartCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUser _authenticatedUserService;

        public UpdateItemFromShoppingCartCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<UpdateItemFromShoppingCartCommandHandler> logger,
            IMapper mapper,
            IUser authenticatedUserService)
        {
            _authenticatedUserService = authenticatedUserService;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateItemFromShoppingCartCommand command, CancellationToken cancellationToken)
        {
            var userId = _authenticatedUserService.Id;

            // Validate input data
            if (string.IsNullOrEmpty(userId) || userId != command.OwnerId)
            {
                _logger.LogWarning($"Unauthorized access attempt by user {userId}.");
                throw new ForbiddenAccessException();
            }

            var shoppingCart = await _unitOfWork.ShoppingCart.GetOneAsync(x => x.ApplicationUserId == userId)
                ?? throw new NotFoundException();

            var shoppingCartItemToUpdate = shoppingCart.ProductItems.FirstOrDefault(x => x.ProductId == command.ItemId);

            if (shoppingCartItemToUpdate == null)
            {
                _logger.LogInformation($"Item with ProductId {command.ItemId} not found in ShoppingCart for user {userId}.");
                throw new NotFoundException();
            }

            // Update the item quantity
            shoppingCartItemToUpdate.Quantity = command.Count;

            // Update the shopping cart item in the database
            _unitOfWork.ShoppingCartItem.Update(shoppingCartItemToUpdate);

            await _unitOfWork.SaveAsync();

            _logger.LogInformation($"Updated item with ProductId {command.ItemId} in ShoppingCart for user {userId}.");

            return new Response<int>(command.ItemId);
        }
    }
}
