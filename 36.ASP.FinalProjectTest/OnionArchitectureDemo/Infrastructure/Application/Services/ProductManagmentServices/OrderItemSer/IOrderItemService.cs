using Infrastructure.Application.DtosForProductManagaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.OrderItemSer
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItemDto>> GetAllOrderItems();
        Task<OrderItemDto> GetOrderItemById(Guid id);
        Task AddOrderItem(CreateOrderItemDto dto);
        Task UpdateOrderItem(UpdateOrderItemDto dto);
        Task DeleteOrderItem(Guid id);
    }
}
