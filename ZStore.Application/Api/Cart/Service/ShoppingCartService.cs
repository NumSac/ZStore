using ZStore.Application.Api.Cart.Queries;
using ZStore.Application.Api.Interfaces;
using ZStore.Domain.Exceptions;
using ZStore.Domain.Utils;
using ZStore.Domain.ViewModels;
using ZStore.Infrastructure.Repository.IRepository;

namespace ZStore.Application.Api.Cart.Service
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;    
        }

        public async Task<Response<ShoppingCartVM>> GetShoppingCart(string userId)
        {
            var shoppingCart = await _unitOfWork.ShoppingCart.GetAsync(sc => sc.ApplicationUserId == userId);
            if (shoppingCart == null)
                throw new ApiException($"No Shopping Cart found for user");

            return new Response<ShoppingCartVM>(new ShoppingCartVM{ });
        }
        /*
        public async Task<Response<string>> AddToShoppingCart(string userId, AddToShoppingCartQuery query)
        {
            var productExists = await _unitOfWork.Product.GetByIdAsync(query.ProductId);
            if (productExists == null)
                throw new ApiException($"Invalid Product Id {query.ProductId}");

            await _unitOfWork.ShoppingCart.AddProductToShoppingCart(userId, productExists);

            await _unitOfWork.SaveAsync();

            return new Response<string>("Product added to cart");
        }
        */
        
        public async Task<Response<string>> UpdateShoppingCartItem()
        {
            throw new NotImplementedException();
        }
        public async Task<Response<string>> RemoveFromShoppingCart()
        {
            throw new NotImplementedException();
        }
    }
}
