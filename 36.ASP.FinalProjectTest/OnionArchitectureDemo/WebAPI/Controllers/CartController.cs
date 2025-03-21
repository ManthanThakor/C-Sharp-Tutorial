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
        public async Task<ActionResult<IEnumerable<CartDto>>> GetAllCartItems()
        {
            IEnumerable<CartDto> cartItems = await _cartService.GetAllCartItems();
            return Ok(cartItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartDto>> GetCartItemById(Guid id)
        {
            var cartItem = await _cartService.GetCartItemById(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        [HttpPost]
        public async Task<ActionResult> AddToCart(CreateCartDto dto)
        {
            await _cartService.AddCartItem(dto);
            return CreatedAtAction(nameof(GetAllCartItems), new { }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCartItem(Guid id, UpdateCartDto dto)
        {
            if (id != dto.CartId)
            {
                return BadRequest();
            }
            await _cartService.UpdateCartItem(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveFromCart(Guid id)
        {
            await _cartService.DeleteCartItem(id);
            return NoContent();
        }

    }
}
