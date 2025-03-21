using Domain.Models;
using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Application.Services.ProductManagmentServices.ProductSer;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.OrderSer
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderItem> _orderItemRepository;
        private readonly IProductService _productService;

        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<OrderItem> orderItemRepository,
            IProductService productService)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _productService = productService;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAll();
            var orderDtos = new List<OrderDto>();

            foreach (var order in orders)
            {
                orderDtos.Add(new OrderDto
                {
                    OrderId = order.Id,
                    OrderDate = order.OrderDate,
                    TotalAmount = order.TotalAmount
                });
            }

            return orderDtos;
        }

        public async Task<OrderDto> GetOrderById(Guid orderId)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order == null)
            {
                return null;
            }

            return new OrderDto
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount
            };
        }

        public async Task CreateOrder(CreateOrderDto dto)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount
            };

            await _orderRepository.Add(order);
        }

        public async Task UpdateOrder(UpdateOrderDto dto)
        {
            var order = await _orderRepository.GetById(dto.OrderId);
            if (order == null) return;

            order.OrderDate = dto.OrderDate;
            order.TotalAmount = dto.TotalAmount;
            await _orderRepository.Update(order);
        }

        public async Task DeleteOrder(Guid orderId)
        {
            var order = await _orderRepository.GetById(orderId);
            if (order == null)
            {
                return;
            }

            await _orderRepository.Delete(order);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsByOrderId(Guid orderId)
        {
            ICollection<OrderItem> orderItems = await _orderItemRepository.FindAll(oi => oi.OrderId == orderId);
            List<ProductDto> productDtos = new List<ProductDto>();

            foreach (OrderItem orderItem in orderItems)
            {
                ProductDto productDto = await _productService.GetProductById(orderItem.ProductId);
                if (productDto != null)
                {
                    productDtos.Add(productDto);
                }
            }

            return productDtos;
        }
    }
}
