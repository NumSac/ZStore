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
    public partial class RemoveItemFromShoppingCartCommand : IRequest<Response<int>>
    {
        public string OwnerId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
    }

    public class RemoveItemFromShoppingCartCommandHandler : IRequestHandler<RemoveItemFromShoppingCartCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RemoveItemFromShoppingCartCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IUser _authenticatedUserService;

        public RemoveItemFromShoppingCartCommandHandler(
            IUnitOfWork unitOfWork,
            ILogger<RemoveItemFromShoppingCartCommandHandler> logger,
            IMapper mapper,
            IUser authenticatedUserService)
        {
            _authenticatedUserService = authenticatedUserService;
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(RemoveItemFromShoppingCartCommand command, CancellationToken cancellationToken)
        {
            var userId = _authenticatedUserService.Id;

            // Validate input data
            if (string.IsNullOrEmpty(userId) || userId != command.OwnerId)
            {
                _logger.LogWarning("Unauthorized access attempt.");
                throw new ForbiddenAccessException();
            }

            // Retrieve shopping cart
            var shoppingCart = await _unitOfWork.ShoppingCart.GetOneAsync(x => x.ApplicationUserId == userId) 
                ?? throw new NotFoundException();

            // Find Item in shopping cart items
            var shoppingCartItemToDelete = shoppingCart.ProductItems.First(x => x.ProductId == command.ItemId) 
                ?? throw new NotFoundException();

            // Delete item
            shoppingCart.ProductItems.Remove(shoppingCartItemToDelete);

            // Save changes
            await _unitOfWork.SaveAsync();

            return new Response<int>(command.ItemId);
        }
    }
}
