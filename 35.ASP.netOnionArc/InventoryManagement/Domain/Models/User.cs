using Domain.CommonEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "User Name must be between 3 and 50 characters")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format")]
        public string UserEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Invalid Phone Number. Use format: +1234567890 or 1234567890")]
        public string UserPhoneNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "User Photo is required")]
        [Url(ErrorMessage = "Invalid URL format for User Photo")]
        public string UserPhoto { get; set; } = string.Empty;

        [Required(ErrorMessage = "User Type is required")]
        public Guid UserTypeId { get; set; }

        [JsonIgnore]
        public virtual UserType? UserType { get; set; }

        public virtual List<SupplierItem> SupplierItems { get; set; } = new List<SupplierItem>();
        public virtual List<CustomerItem> CustomerItems { get; set; } = new List<CustomerItem>();
    }
}
