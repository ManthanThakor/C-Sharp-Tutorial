using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.OrderSer;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(Guid id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByOrderId(Guid id)
        {
            var products = await _orderService.GetProductsByOrderId(id);
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderDto dto)
        {
            await _orderService.CreateOrder(dto);
            return CreatedAtAction(nameof(GetAllOrders), new { }, null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(Guid id, UpdateOrderDto dto)
        {
            if (id != dto.OrderId)
            {
                return BadRequest();
            }
            await _orderService.UpdateOrder(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
        {
            await _orderService.DeleteOrder(id);
            return NoContent();
        }
    }
}
