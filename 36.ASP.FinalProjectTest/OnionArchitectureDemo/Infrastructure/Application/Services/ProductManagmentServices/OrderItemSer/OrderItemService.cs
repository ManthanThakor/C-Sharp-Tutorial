using Domain.Models;
using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.OrderSer;
using Infrastructure.Application.Services.ProductManagmentServices.ProductSer;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.OrderItemSer
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;


        public OrderItemService(
            IRepository<OrderItem> orderItemRepository,
            IProductService productService, IOrderService orderService)
        {
            _orderItemRepository = orderItemRepository;
            _productService = productService;
            _orderService = orderService;

        }

        public async Task<IEnumerable<OrderItemDto>> GetAllOrderItems()
        {
            IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetAll();
            List<OrderItemDto> orderItemDtos = new List<OrderItemDto>();

            foreach (var orderItem in orderItems)
            {
                var productDto = await _productService.GetProductById(orderItem.ProductId);
                var orderDto = await _orderService.GetOrderById(orderItem.OrderId);

                var orderItemDto = new OrderItemDto
                {
                    OrderItemId = orderItem.Id,
                    OrderId = orderItem.OrderId,
                    ProductId = orderItem.ProductId,
                    Quantity = orderItem.Quantity,
                    UnitPrice = orderItem.UnitPrice,
                    Product = productDto,
                    Order = orderDto
                };

                orderItemDtos.Add(orderItemDto);
            }

            return orderItemDtos;
        }

        public async Task<OrderItemDto> GetOrderItemById(Guid id)
        {
            var orderItem = await _orderItemRepository.GetById(id);
            if (orderItem == null)
            {
                return null;
            }

            var productDto = await _productService.GetProductById(orderItem.ProductId);

            return new OrderItemDto
            {
                OrderItemId = orderItem.Id,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
                Product = productDto
            };
        }
        public async Task AddOrderItem(CreateOrderItemDto dto)
        {
            var orderItem = new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice
            };

            await _orderItemRepository.Add(orderItem);
        }

        public async Task UpdateOrderItem(UpdateOrderItemDto dto)
        {
            var orderItem = await _orderItemRepository.GetById(dto.OrderItemId);
            if (orderItem == null)
            {
                return;
            }

            orderItem.OrderId = dto.OrderId;
            orderItem.ProductId = dto.ProductId;
            orderItem.Quantity = dto.Quantity;
            orderItem.UnitPrice = dto.UnitPrice;

            await _orderItemRepository.Update(orderItem);
        }

        public async Task DeleteOrderItem(Guid id)
        {
            var orderItem = await _orderItemRepository.GetById(id);
            if (orderItem == null)
            {
                return;
            }

            await _orderItemRepository.Delete(orderItem);
        }
    }
}
