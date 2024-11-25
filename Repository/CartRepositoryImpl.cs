using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuitQ_Ecom.DTOs;
using QuitQ_Ecom.Exceptions;
using QuitQ_Ecom.Models;

namespace QuitQ_Ecom.Repository
{
    public class CartRepositoryImpl : ICart
    {
        private readonly QuitQEcomContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CartRepositoryImpl> _logger;

        public CartRepositoryImpl(QuitQEcomContext quitQEcomContext, IMapper mapper, ILogger<CartRepositoryImpl> logger)
        {
            _context = quitQEcomContext;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<CartDTO>> GetUserCartItems(int userId)
        {
            try
            {
                var cartItems = await _context.Carts
                    .Where(c => c.UserId == userId)
                    .ToListAsync();

                List<CartDTO> cartItemsDto = _mapper.Map<List<CartDTO>>(cartItems);
                foreach (var cartItem in cartItemsDto)
                {
                    var productObj = await _context.Products.FindAsync(cartItem.ProductId);
                    if (productObj != null)
                    {
                        cartItem.ProductPrice = productObj.Price;
                        cartItem.ProductName = productObj.ProductName;
                        cartItem.ProductImage = productObj.ProductImage;
                    }
                }

                return cartItemsDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get user cart items.");
                throw new GetUserCartItemsException("Failed to get user cart items.", ex);
            }
        }

        public async Task<CartDTO> AddNewProductToCart(CartDTO cartItem)
        {
            try
            {
                if (cartItem.Quantity <= 0)
                {
                    throw new InvalidCartItemException("Quantity should be greater than zero.");
                }

                var product = await _context.Products.FindAsync(cartItem.ProductId);
                if (product == null)
                {
                    throw new ProductNotFoundException($"Product with ID {cartItem.ProductId} not found.");
                }

                if (product.Quantity < cartItem.Quantity)
                {
                    throw new InsufficientStockException($"Insufficient stock for product {product.ProductName}.");
                }

                var cart = _mapper.Map<Cart>(cartItem);
                cart.Product = product;
                _context.Carts.Add(cart);
                await _context.SaveChangesAsync();
                return _mapper.Map<CartDTO>(cart);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add new product to cart.");
                throw new AddNewProductToCartException("Failed to add new product to cart.", ex);
            }
        }

        public async Task<bool> IncreaseProductQuantity(int cartItemId)
        {
            try
            {
                var cartItem = await _context.Carts.FindAsync(cartItemId);
                if (cartItem == null)
                {
                    throw new CartNotFoundException($"Cart item with ID {cartItemId} not found.");
                }

                //var product = await _context.Products.FindAsync(cartItem.ProductId);
                //if (product == null)
                //{
                //    throw new ProductNotFoundException($"Product with ID {cartItem.ProductId} not found.");
                //}

                //if (product.Quantity < cartItem.Quantity + 1)
                //{
                //    throw new InsufficientStockException($"Insufficient stock for product {product.ProductName}.");
                //}

                cartItem.Quantity++;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to increase product quantity in cart.");
                throw new IncreaseProductQuantityException("Failed to increase product quantity in cart.", ex);
            }
        }

        public async Task<bool> DecreaseProductQuantity(int cartItemId)
        {
            try
            {
                var cartItem = await _context.Carts.FindAsync(cartItemId);
                if (cartItem == null)
                {
                    throw new CartNotFoundException($"Cart item with ID {cartItemId} not found.");
                }
                cartItem.Quantity--;
                if (cartItem.Quantity <= 0)
                {
                    _context.Carts.Remove(cartItem);
                }

                await _context.SaveChangesAsync();

                return true;

                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to decrease product quantity in cart.");
                throw new DecreaseProductQuantityException("Failed to decrease product quantity in cart.", ex);
            }
        }

        public async Task<bool> RemoveProductFromCart(int cartId)
        {
            try
            {
                var cartItem = await _context.Carts.FirstOrDefaultAsync(c => c.CartId == cartId);
                if (cartItem == null)
                {
                    throw new CartNotFoundException($"Cart item with ID {cartId} not found.");
                }

                _context.Carts.Remove(cartItem);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to remove product from cart.");
                throw new RemoveProductFromCartException("Failed to remove product from cart.", ex);
            }
        }

        // Implement other methods with custom exceptions...

        public async Task<decimal> GetTotalCartCost(int userId)
        {
            try
            {
                var cartItems = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
                decimal totalCost = 0;

                foreach (var cartItem in cartItems)
                {
                    var product = await _context.Products.FindAsync(cartItem.ProductId);
                    if (product != null)
                    {
                        totalCost += product.Price * cartItem.Quantity;
                    }
                }

                return totalCost;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to calculate total cart cost.");
                throw new GetTotalCartCostException("Failed to calculate total cart cost.", ex);
            }
        }

        public async Task<bool> RemoveCartItemsOfUser(int userId)
        {
            try
            {
                var cartItems = await _context.Carts.Where(c => c.UserId == userId).ToListAsync();
                if (cartItems != null && cartItems.Any())
                {
                    _context.Carts.RemoveRange(cartItems);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to remove cart items of user.");
                throw new RemoveCartItemsOfUserException("Failed to remove cart items of user.", ex);
            }
        }
    }
}
