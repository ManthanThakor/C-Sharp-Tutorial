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
        Task<IEnumerable<OrderItemDto>> GetAllOrderItemsAsync();
        Task<OrderItemDto> GetOrderItemByIdAsync(Guid id);
        Task AddOrderItemAsync(CreateOrderItemDto dto);
        Task UpdateOrderItemAsync(UpdateOrderItemDto dto);
        Task DeleteOrderItemAsync(Guid id);
    }

}
