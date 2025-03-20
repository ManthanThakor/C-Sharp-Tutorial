using Infrastructure.Application.DtosForProductManagaments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.ProductManagmentServices.CategorySer
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategories();
        Task<CategoryDto> GetCategoryById(Guid id);
        Task AddCategory(CreateCategoryDto dto);
        Task UpdateCategory(UpdateCategoryDto dto);
        Task DeleteCategory(Guid id);
    }

}
