using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.OrderItemSer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/order-items")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        private readonly ILogger<OrderItemsController> _logger;

        public OrderItemsController(IOrderItemService orderItemService, ILogger<OrderItemsController> logger)
        {
            _orderItemService = orderItemService;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetAll()
        {
            try
            {
                var orderItems = await _orderItemService.GetAllOrderItems();
                return Ok(orderItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all order items.");
                return StatusCode(500, "An error occurred while retrieving order items.");
            }
        }

        [HttpGet("{orderItemId:guid}")]
        public async Task<ActionResult<OrderItemDto>> GetById(Guid orderItemId)
        {
            try
            {
                var orderItem = await _orderItemService.GetOrderItemById(orderItemId);
                if (orderItem == null)
                {
                    _logger.LogWarning("Order item with ID {OrderItemId} not found.", orderItemId);
                    return NotFound("Order item not found.");
                }
                return Ok(orderItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while retrieving order item with ID {OrderItemId}.", orderItemId);
                return StatusCode(500, "An error occurred while retrieving the order item.");
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateOrderItemDto dto)
        {
            try
            {
                await _orderItemService.AddOrderItem(dto);
                _logger.LogInformation("Order item created successfully.");
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while creating order item.");
                return StatusCode(500, "An error occurred while creating the order item.");
            }
        }

        [HttpPut("update/{orderItemId:guid}")]
        public async Task<ActionResult> Update(Guid orderItemId, [FromBody] UpdateOrderItemDto dto)
        {
            if (orderItemId != dto.OrderItemId)
            {
                _logger.LogWarning("Order item ID mismatch. Provided ID: {ProvidedId}, DTO ID: {DtoId}", orderItemId, dto.OrderItemId);
                return BadRequest("Order item ID mismatch.");
            }

            try
            {
                await _orderItemService.UpdateOrderItem(dto);
                _logger.LogInformation("Order item with ID {OrderItemId} updated successfully.", orderItemId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while updating order item with ID {OrderItemId}.", orderItemId);
                return StatusCode(500, "An error occurred while updating the order item.");
            }
        }

        [HttpDelete("delete/{orderItemId:guid}")]
        public async Task<ActionResult> Delete(Guid orderItemId)
        {
            try
            {
                await _orderItemService.DeleteOrderItem(orderItemId);
                _logger.LogInformation("Order item with ID {OrderItemId} deleted successfully.", orderItemId);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while deleting order item with ID {OrderItemId}.", orderItemId);
                return StatusCode(500, "An error occurred while deleting the order item.");
            }
        }
    }
}
