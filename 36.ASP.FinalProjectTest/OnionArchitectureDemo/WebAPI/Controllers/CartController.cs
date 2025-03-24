using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.CartSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ILogger<CartController> _logger;

        public CartController(ICartService cartService, ILogger<CartController> logger)
        {
            _cartService = cartService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cartItems = await _cartService.GetAllCartItems();
                return Ok(cartItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all cart items.");
                return StatusCode(500, "An error occurred while retrieving cart items.");
            }
        }

        [HttpGet("{cartItemId:guid}")]
        public async Task<IActionResult> GetById(Guid cartItemId)
        {
            try
            {
                var cartItem = await _cartService.GetCartItemById(cartItemId);
                if (cartItem == null)
                {
                    _logger.LogWarning("Cart item with ID {CartItemId} not found.", cartItemId);
                    return NotFound("Cart item not found.");
                }
                return Ok(cartItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving cart item with ID {CartItemId}.", cartItemId);
                return StatusCode(500, "An error occurred while retrieving the cart item.");
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCartDto cartDto)
        {
            try
            {
                await _cartService.AddCartItem(cartDto);
                _logger.LogInformation("Cart item added successfully.");
                return CreatedAtAction(nameof(GetById), new { cartItemId = cartDto.ProductId }, cartDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding cart item.");
                return StatusCode(500, "An error occurred while adding the cart item.");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCartDto cartDto)
        {
            try
            {
                await _cartService.UpdateCartItem(cartDto);
                _logger.LogInformation("Cart item updated successfully.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating cart item.");
                return StatusCode(500, "An error occurred while updating the cart item.");
            }
        }

        [HttpDelete("delete/{cartItemId:guid}")]
        public async Task<IActionResult> Delete(Guid cartItemId)
        {
            try
            {
                await _cartService.DeleteCartItem(cartItemId);
                _logger.LogInformation("Cart item with ID {CartItemId} deleted successfully.", cartItemId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting cart item with ID {CartItemId}.", cartItemId);
                return StatusCode(500, "An error occurred while deleting the cart item.");
            }
        }

        [HttpGet("category/{cartItemId:guid}")]
        public async Task<IActionResult> GetCategoryByCartId(Guid cartItemId)
        {
            try
            {
                CartDto cartItem = await _cartService.GetCartItemById(cartItemId);
                if (cartItem == null)
                {
                    _logger.LogWarning("Cart item with ID {CartItemId} not found.", cartItemId);
                    return NotFound("Cart item not found.");
                }

                if (cartItem.Product == null)
                {
                    _logger.LogWarning("Product not found for cart item with ID {CartItemId}.", cartItemId);
                    return NotFound("Product not found for this cart item.");
                }

                if (cartItem.Product.Category == null)
                {
                    _logger.LogWarning("Category not found for product in cart item with ID {CartItemId}.", cartItemId);
                    return NotFound("Category not found for this product.");
                }

                return Ok(cartItem.Product.Category.CategoryName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching category for cart item with ID {CartItemId}.", cartItemId);
                return StatusCode(500, "An error occurred while retrieving the category.");
            }
        }
    }
}
