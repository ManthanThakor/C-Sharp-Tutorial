using Domain.Models;
using Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Service.CustomServices.CustomerServices
{
    public interface ICustomerService
    {
        Task<ICollection<UserViewModel>> GetAll();
        Task<UserViewModel> Get(Guid Id);
        User GetLast();
        Task<bool> Insert(UserInsertModel userInsertModel, string photo);
        Task<bool> Update(UserUpdateModel userUpdateModel, string photo);
        Task<bool> Delete(Guid Id);
        Task<User> Find(Expression<Func<User, bool>> match);
    }
}
