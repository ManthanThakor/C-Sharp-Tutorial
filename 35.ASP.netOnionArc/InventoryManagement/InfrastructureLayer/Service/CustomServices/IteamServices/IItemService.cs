using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Infrastructure.Services.CustomServices.ItemServices
{
    public interface IItemService
    {
        Task<ICollection<ItemViewModel>> GetAllItemByUser(Guid id);
        Task<ItemViewModel> Get(Guid Id);
        Item GetLast();
        Task<bool> Insert(ItemInsertModel itemInsertModel, string imagePath);
        Task<bool> Update(ItemUpdateModel itemUpdateModel, string imagePath);
        Task<bool> Delete(Guid Id);
        Task<Item> Find(Expression<Func<Item, bool>> match);
        Task<ICollection<Item>> FindAll(Expression<Func<Item, bool>> match);
    }
}
