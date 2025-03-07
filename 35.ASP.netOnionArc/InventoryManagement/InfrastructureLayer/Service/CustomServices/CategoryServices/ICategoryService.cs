using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Service.CustomServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> Get(Guid Id);
        Category GetLast();
        Task<bool> Insert(CategoryInsertModel categoryInsertModel);
        Task<bool> Update(CategoryUpdateModel categoryUpdateModel);
        Task<bool> Delete(Guid Id);
        Task<Category> Find(Expression<Func<Category, bool>> match);
    }
}
