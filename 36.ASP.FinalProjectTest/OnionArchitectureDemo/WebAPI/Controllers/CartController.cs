using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.CartSer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartItems()
        {
            var cartItems = await _cartService.GetAllCartItems();
            return Ok(cartItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItemById(Guid id)
        {
            var cartItem = await _cartService.GetCartItemById(id);
            if (cartItem == null)
                return NotFound("Cart item not found");

            return Ok(cartItem);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody] CreateCartDto cartDto)
        {
            await _cartService.AddCartItem(cartDto);
            return CreatedAtAction(nameof(GetCartItemById), new { id = cartDto.ProductId }, cartDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartDto cartDto)
        {
            await _cartService.UpdateCartItem(cartDto);
            return Ok("Cart item updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(Guid id)
        {
            await _cartService.DeleteCartItem(id);
            return Ok("Cart item deleted successfully");
        }

        [HttpGet("category/{cartId}")]
        public async Task<IActionResult> GetCategoryByCartId(Guid cartId)
        {
            var cartItem = await _cartService.GetCartItemById(cartId);
            if (cartItem == null)
                return NotFound("Cart item not found");

            var categoryName = cartItem.Product?.CategoryName ?? "Category not found";
            return Ok(categoryName);
        }
    }
}
