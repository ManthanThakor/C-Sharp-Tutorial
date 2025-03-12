using Domain.CommonEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class SupplierItem : BaseEntity
    {
        [Required]
        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        public virtual User? Supplier { get; set; }

        [Required]
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }
        public virtual Item? Item { get; set; }
    }
}
    