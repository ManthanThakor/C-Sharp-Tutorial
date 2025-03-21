using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.OrderItemSer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemsController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetAllOrderItems()
        {
            var orderItems = await _orderItemService.GetAllOrderItems();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetOrderItemById(Guid id)
        {
            var orderItem = await _orderItemService.GetOrderItemById(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrderItem(CreateOrderItemDto dto)
        {
            await _orderItemService.AddOrderItem(dto);
            return CreatedAtAction(nameof(GetAllOrderItems), new { }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderItem(Guid id, UpdateOrderItemDto dto)
        {
            if (id != dto.OrderItemId)
            {
                return BadRequest();
            }
            await _orderItemService.UpdateOrderItem(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderItem(Guid id)
        {
            await _orderItemService.DeleteOrderItem(id);
            return NoContent();
        }
    }
}
