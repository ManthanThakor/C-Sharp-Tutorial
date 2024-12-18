using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserRegistration.Models
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
        UserModel GetUserById(int userId);
        void InsertUser(UserModel user);
        void DeleteUser(int userId);
        void UpdateUser(UserModel user);
    }
}