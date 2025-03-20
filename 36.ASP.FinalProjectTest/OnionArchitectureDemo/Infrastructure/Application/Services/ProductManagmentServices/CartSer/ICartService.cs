using Infrastructure.Application.DtosForProductManagaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.CartSer
{
    public interface ICartService
    {
        Task<IEnumerable<CartDto>> GetAllCarts();
        Task<CartDto> GetCartById(Guid id);
        Task AddCart(CreateCartDto dto);
        Task UpdateCart(UpdateCartDto dto);
        Task DeleteCart(Guid id);
    }

}
