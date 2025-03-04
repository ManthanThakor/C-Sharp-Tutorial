using Domain.CommonEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Item : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public string ItemCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? ItemDescription { get; set; }

        [Required]
        [Range(0.01, 999999.99)]
        public decimal ItemPrice { get; set; }

        [Required]
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual List<ItemImage> ItemImages { get; set; } = new List<ItemImage>();

        public virtual List<SupplierItem> SupplierItems { get; set; } = new List<SupplierItem>();
        public virtual List<CustomerItem> CustomerItems { get; set; } = new List<CustomerItem>();
    }

}
