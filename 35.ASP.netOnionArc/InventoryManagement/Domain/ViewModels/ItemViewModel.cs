using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.ViewModels
{
    public class ItemViewModel
    {
        public Guid ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public List<CategoryViewModel> Category { get; set; } = new List<CategoryViewModel>();
        public List<ItemImagesView> ItemImages { get; set; } = new List<ItemImagesView>();
        public List<UserView> User { get; set; } = new List<UserView>();
    }

    public class ItemInsertModel
    {
        [Required(ErrorMessage = "Plaese Enter Item Code.")]
        public string ItemCode { get; set; }

        [Required(ErrorMessage = "Plaese Enter Item Name.")]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        [Required(ErrorMessage = "Plaese Select Category Id.")]
        public Guid CategoryId { get; set; }
        [Required(ErrorMessage = "Plaese Select User Id")]
        public Guid UserId { get; set; }
        public IFormFile ItemImage { get; set; }
        public bool IsActive { get; set; }
    }

    public class ItemUpdateModel : ItemInsertModel
    {
        [Required(ErrorMessage = "Id is compulsory for Update.")]
        public Guid Id { get; set; }
    }

    public class ItemImagesView
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string ItemImage { get; set; }
        public bool? IsActive { get; set; }
    }

    public class UserView
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserAddress { get; set; }
        public string UserPhoneNo { get; set; }
        public string UserPhoto { get; set; }

    }
}