using Domain.Models;
using Domain.ViewModels;
using InfrastructureLayer.Repository;
using InfrastructureLayer.Service.CustomServices.UserTypeServices;
using Services.common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfrastructureLayer.Service.CustomServices.SupplierServices
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUserTypeService _userTypeService;

        public SupplierService(IRepository<User> userRepository, IUserTypeService userTypeService)
        {
            _userRepository = userRepository;
            _userTypeService = userTypeService;
        }

        public async Task<ICollection<UserViewModel>> GetAll()
        {
            UserType userType = await _userTypeService.Find(x => x.TypeName == "Supplier");
            ICollection<UserViewModel> SupplierViewModels = new List<UserViewModel>();
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
                SupplierViewModels.Add(userViewMod);
            }
            return users == null ? null : SupplierViewModels;
        }

        public async Task<UserViewModel> Get(Guid Id)
        {
            var user = await _userRepository.Get(Id);
            UserType userType = await _userTypeService.Find(x => x.TypeName == "Supplier");

            if (user == null || user.UserTypeId != userType.Id)
                return null;

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

        public User GetLast()
        {
            return _userRepository.GetLast();
        }

        public async Task<bool> Insert(UserInsertModel userInsertModel, string photo)
        {
            UserType supplierUserType = await _userTypeService.Find(ut => ut.TypeName.ToLower() == "supplier");
            if (supplierUserType == null)
                return false;

            User user = new()
            {
                UserId = userInsertModel.UserId,
                UserName = userInsertModel.UserName,
                UserEmail = userInsertModel.UserEmail,
                UserPassword = Encryptor.EncryptString(userInsertModel.UserPassword),
                UserAddress = userInsertModel.UserAddress,
                UserPhoneNo = userInsertModel.UserPhoneNo,
                UserTypeId = supplierUserType.Id,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now,
                IsActive = userInsertModel.IsActive,
                UserPhoto = photo
            };
            return await _userRepository.Insert(user);
        }

        public async Task<bool> Update(UserUpdateModel userUpdateModel, string photo)
        {
            User user = await _userRepository.Get(userUpdateModel.Id);
            if (user == null)
                return false;

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

        public async Task<bool> Delete(Guid Id)
        {
            if (Id == Guid.Empty)
                return false;

            User user = await _userRepository.Get(Id);
            if (user == null)
                return false;

            await _userRepository.Delete(user);
            return true;
        }

        public Task<User> Find(Expression<Func<User, bool>> match)
        {
            return _userRepository.Find(match);
        }
    }
}