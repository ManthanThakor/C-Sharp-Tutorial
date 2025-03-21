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
        Task<IEnumerable<CartDto>> GetAllCartItems();
        Task<CartDto> GetCartItemById(Guid id);
        Task AddCartItem(CreateCartDto dto);
        Task UpdateCartItem(UpdateCartDto dto);
        Task DeleteCartItem(Guid id);
        Task<string> GetCategoryNameByCartId(Guid cartId);
    }


}
