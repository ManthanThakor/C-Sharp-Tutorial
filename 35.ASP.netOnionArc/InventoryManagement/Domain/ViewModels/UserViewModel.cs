using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoneNo { get; set; }
        public string UserPhoto { get; set; }
        public List<UserTypeViewModel> UserType { get; set; } = new List<UserTypeViewModel>();

    }

    public class UserInsertModel
    {

        public string UserId { get; set; }

        [Required(ErrorMessage = "Please Enter Name.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Email.")]
        [EmailAddress(ErrorMessage = "Enter Valid Email Address.")]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Address.")]
        public string UserAddress { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number.")]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Invalid Phone Number.")]
        public string UserPhoneNo { get; set; }

        [Required(ErrorMessage = "Please Enter Photo Path.")]
        public IFormFile UserPhoto { get; set; }

        public bool IsActive { get; set; } = true;
        public Guid UserTypeId { get; set; }


    }

    public class UserUpdateModel : UserInsertModel
    {
        [Required(ErrorMessage = "Id is compulsory For Update.")]
        public Guid Id { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Please Enter UserName.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password.")]
        public string Password { get; set; }
    }
}