using Infrastructure.Application.DtosForProductManagaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.ProductSer
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<ProductDto> GetProductById(Guid id);
        Task AddProduct(CreateProductDto dto);
        Task UpdateProduct(UpdateProductDto dto);
        Task DeleteProduct(Guid id);
    }
}
