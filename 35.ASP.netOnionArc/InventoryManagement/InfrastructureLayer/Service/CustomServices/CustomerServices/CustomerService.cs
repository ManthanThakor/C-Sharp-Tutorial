using Domain.Models;
using Domain.ViewModels;
using InfrastructureLayer.Repository;
using InfrastructureLayer.Service.CustomServices.CustomerServices;
using InfrastructureLayer.Service.CustomServices.UserTypeServices;
using Services.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfrastructureLayer.Service.CustomServices.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUserTypeService _userTypeService;

        public CustomerService(IRepository<User> userRepository, IUserTypeService userTypeService)
        {
            _userRepository = userRepository;
            _userTypeService = userTypeService;
        }

        public async Task<ICollection<UserViewModel>> GetAll()
        {
            UserType userType = await _userTypeService.Find(x => x.TypeName == "Customer");
            ICollection<UserViewModel> CustomerViewModels = new List<UserViewModel>();
            ICollection<User> users = await _userRepository.FindAll(x => x.UserTypeId == userType.Id);

            foreach (User user in users)
            {
                UserViewModel userViewMod = new()
                {
                    Id = user.Id,
                    UserId = user.UserId,
                    UserName = user.UserName,
                    UserEmail = user.UserEmail,
                    UserPassword = Encryptor.DecryptString(user.UserPassword),
                    UserAddress = user.UserAddress,
                    UserPhoneNo = user.UserPhoneNo,
                    UserPhoto = user.UserPhoto,
                };
                UserTypeViewModel userView = new();
                if (userType != null)
                {
                    userView.Id = userType.Id;
                    userView.TypeName = userType.TypeName;
                    userViewMod.UserType.Add(userView);
                }
                CustomerViewModels.Add(userViewMod);
            }
            if (users == null)
                return null;

            return CustomerViewModels;
        }

        public async Task<UserViewModel> Get(Guid Id)
        {
            var user = await _userRepository.Get(Id);
            UserType userType = await _userTypeService.Find(x => x.TypeName == "Customer");

            if (user == null)
                return null;
            else
            {
                if (user.UserTypeId == userType.Id)

                {
                    UserViewModel userViewModel = new()
                    {
                        Id = user.Id,
                        UserId = user.UserId,
                        UserName = user.UserName,
                        UserEmail = user.UserEmail,
                        UserPassword = Encryptor.DecryptString(user.UserPassword),
                        UserAddress = user.UserAddress,
                        UserPhoneNo = user.UserPhoneNo,
                        UserPhoto = user.UserPhoto,
                    };
                    UserTypeViewModel userView = new();
                    if (userType != null)
                    {
                        userView.Id = userType.Id;
                        userView.TypeName = userType.TypeName;
                        userViewModel.UserType.Add(userView);
                    }
                    return userViewModel;

                }

                return null;
            }

        }

        public User GetLast()
        {
            return _userRepository.GetLast();
        }

        public async Task<bool> Insert(UserInsertModel userInsertModel, string photo)
        {

            UserType customerUserType = await _userTypeService.Find(ut => ut.TypeName.ToLower() == "customer");

            if (customerUserType == null)
                return false;

            User user = new()
            {
                UserId = userInsertModel.UserId,
                UserName = userInsertModel.UserName,
                UserEmail = userInsertModel.UserEmail,
                UserPassword = Encryptor.EncryptString(userInsertModel.UserPassword),
                UserAddress = userInsertModel.UserAddress,
                UserPhoneNo = userInsertModel.UserPhoneNo,
                UserTypeId = customerUserType.Id,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                IsActive = userInsertModel.IsActive,
                UserPhoto = photo
            };

            var ans = await _userRepository.Insert(user);
            return ans;
        }

        public async Task<bool> Update(UserUpdateModel userUpdateModel, string photo)
        {
            User user = await _userRepository.Get(userUpdateModel.Id);

            if (user != null)
            {
                user.UserId = userUpdateModel.UserId;
                user.UserName = userUpdateModel.UserName;
                user.UserEmail = userUpdateModel.UserEmail;
                user.UserPassword = Encryptor.EncryptString(userUpdateModel.UserPassword);
                user.UserAddress = userUpdateModel.UserAddress;
                user.UserPhoneNo = userUpdateModel.UserPhoneNo;
                user.UserTypeId = userUpdateModel.UserTypeId;
                user.UpdatedOn = DateTime.Now;
                user.IsActive = userUpdateModel.IsActive;

                user.UserPhoto = string.IsNullOrWhiteSpace(photo) ? user.UserPhoto : photo;

                return await _userRepository.Update(user);
            }
            return false;
        }


        public async Task<bool> Delete(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                User user = await _userRepository.Get(Id);
                if (user != null)
                {
                    await _userRepository.Delete(user);
                    return true;
                }
            }
            return false;
        }


        public Task<User> Find(Expression<Func<User, bool>> match)
        {
            return _userRepository.Find(match);
        }
    }
}
