using Domain.Models;
using Infrastructure.Application.DtosForProductManagaments;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.OrderSer
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAll();
            return orders.Select(o => new OrderDto
            {
                OrderId = o.Id,
                OrderDate = o.OrderDate,
                TotalAmount = o.TotalAmount
            }).ToList();
        }

        public async Task<OrderDto> GetOrderById(Guid id)
        {
            var order = await _orderRepository.GetById(id);
            return order == null ? null : new OrderDto { OrderId = order.Id, OrderDate = order.OrderDate, TotalAmount = order.TotalAmount };
        }

        public async Task AddOrder(CreateOrderDto dto)
        {
            var order = new Order { Id = Guid.NewGuid(), OrderDate = dto.OrderDate, TotalAmount = dto.TotalAmount };
            await _orderRepository.Add(order);
        }

        public async Task UpdateOrder(UpdateOrderDto dto)
        {
            var order = await _orderRepository.GetById(dto.OrderId);
            if (order != null)
            {
                order.OrderDate = dto.OrderDate;
                order.TotalAmount = dto.TotalAmount;
                await _orderRepository.Update(order);
            }
        }

        public async Task DeleteOrder(Guid id)
        {
            var order = await _orderRepository.GetById(id);
            if (order != null)
                await _orderRepository.Delete(order);
        }
    }

}
