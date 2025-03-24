using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.OrderSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAll()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderDto>> GetById(Guid orderId)
        {
            var order = await _orderService.GetOrderById(orderId);
            if (order == null)
            {
                return NotFound("Order not found");
            }
            return Ok(order);
        }

        [HttpGet("{orderId}/products")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(Guid orderId)
        {
            var products = await _orderService.GetProductsByOrderId(orderId);
            return Ok(products);
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateOrderDto dto)
        {
            await _orderService.CreateOrder(dto);
            return CreatedAtAction(nameof(GetAll), new { }, null);
        }

        [HttpPut("update/{orderId}")]
        public async Task<ActionResult> Update(Guid orderId, [FromBody] UpdateOrderDto dto)
        {
            if (orderId != dto.OrderId)
            {
                return BadRequest("Order ID mismatch");
            }

            await _orderService.UpdateOrder(dto);
            return NoContent();
        }

        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult> Delete(Guid orderId)
        {
            await _orderService.DeleteOrder(orderId);
            return NoContent();
        }
    }
}
