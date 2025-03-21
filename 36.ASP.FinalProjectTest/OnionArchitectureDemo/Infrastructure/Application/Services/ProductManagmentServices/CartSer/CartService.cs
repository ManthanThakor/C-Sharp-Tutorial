using Domain.Models;
using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.ProductSer;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.CartSer
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IProductService _productService;

        public CartService(
            IRepository<Cart> cartRepository,
            IProductService productService)
        {
            _cartRepository = cartRepository;
            _productService = productService;
        }

        public async Task<IEnumerable<CartDto>> GetAllCartItems()
        {
            IEnumerable<Cart> cartItems = await _cartRepository.GetAll();
            List<CartDto> cartDtos = new List<CartDto>();

            foreach (var cartItem in cartItems)
            {
                var productDto = await _productService.GetProductById(cartItem.ProductId);

                var cartDto = new CartDto
                {
                    CartId = cartItem.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Product = productDto
                };

                cartDtos.Add(cartDto);
            }

            return cartDtos;
        }

        public async Task<CartDto> GetCartItemById(Guid id)
        {
            var cartItem = await _cartRepository.GetById(id);
            if (cartItem == null)
            {
                return null;
            }

            var productDto = await _productService.GetProductById(cartItem.ProductId);

            return new CartDto
            {
                CartId = cartItem.Id,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Product = productDto
            };
        }

        public async Task AddCartItem(CreateCartDto dto)
        {
            Cart cartItem = new Cart
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };

            await _cartRepository.Add(cartItem);
        }

        public async Task UpdateCartItem(UpdateCartDto dto)
        {
            var cartItem = await _cartRepository.GetById(dto.CartId);
            if (cartItem == null)
            {
                return;
            }

            cartItem.ProductId = dto.ProductId;
            cartItem.Quantity = dto.Quantity;

            await _cartRepository.Update(cartItem);
        }

        public async Task DeleteCartItem(Guid id)
        {
            var cartItem = await _cartRepository.GetById(id);
            if (cartItem == null)
            {
                return;
            }

            await _cartRepository.Delete(cartItem);
        }
    }
}
