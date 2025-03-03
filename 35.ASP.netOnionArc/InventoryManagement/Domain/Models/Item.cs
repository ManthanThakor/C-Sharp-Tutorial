using Domain.CommonEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Item : BaseEntity
    {
        [Required]
        public string ItemCode { get; set; }

        [Required]
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual List<ItemImage> ItemImages { get; set; } = new List<ItemImage>();

        public virtual List<SupplierItem> SupplierItems { get; set; } = new List<SupplierItem>();
        public virtual List<CustomerItem> CustomerItems { get; set; } = new List<CustomerItem>();
    }
}
