using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserRegistration.Models
{
    public class UserRepository : IUserRepository
    {
        private UserDataContext _dataContext;

        public UserRepository()
        {
            string connectionString = "Data Source=TGS147\\SQLEXPRESS;Initial Catalog=UserRegistration;Integrated Security=True;Trust Server Certificate=True";

            _dataContext = new UserDataContext(connectionString);
        }

        public IEnumerable<UserModel> GetUser()
        {
            IList<UserModel> userList = new List<UserModel>();

            var users = _dataContext.Users.ToList();
            foreach (var userData in users)
            {
                userList.Add(new UserModel()
                {
                    Id = userData.Id,
                    Name = userData.Name,
                    Email = userData.Email,
                    Age = userData.Age
                });
            }
            return userList;
        }

        public UserModel GetUserById(int userId)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var model = new UserModel()
                {
                    Id = userId,
                    Name = user.Name,
                    Email = user.Email,
                    Age = user.Age
                };
                return model;
            }
            return null;
        }

        public void InserUser(UserModel user)
        {
            var userData = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Age = user.Age
            };
            _dataContext.Users.InsertOnSubmit(userData);
            _dataContext.SubmitChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _dataContext.Users.SingleOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _dataContext.Users.DeleteOnSubmit(user);
                _dataContext.SubmitChanges();
            }
        }

        public void UpdateUser(UserModel user)
        {
            var userData = _dataContext.Users
                .SingleOrDefault(u => u.Id == user.Id);
            if (userData != null)
            {
                userData.Name = user.Name;
                userData.Email = user.Email;
                userData.Age = user.Age;
                _dataContext.SubmitChanges();
            }
        }

        public IEnumerable<UserModel> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void InsertUser(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
