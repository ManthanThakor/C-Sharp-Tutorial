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
        Task<IEnumerable<CartDto>> GetAllCartsAsync();
        Task<CartDto> GetCartByIdAsync(Guid id);
        Task AddCartAsync(CreateCartDto dto);
        Task UpdateCartAsync(UpdateCartDto dto);
        Task DeleteCartAsync(Guid id);
    }

}
