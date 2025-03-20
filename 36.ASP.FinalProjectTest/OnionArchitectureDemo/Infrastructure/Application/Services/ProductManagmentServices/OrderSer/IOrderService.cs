using Infrastructure.Application.DtosForProductManagaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.OrderSer
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrders();
        Task<OrderDto> GetOrderById(Guid id);
        Task AddOrder(CreateOrderDto dto);
        Task UpdateOrder(UpdateOrderDto dto);
        Task DeleteOrder(Guid id);
    }

}
