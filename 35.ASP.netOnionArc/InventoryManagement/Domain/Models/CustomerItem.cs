using Domain.CommonEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class CustomerItem : BaseEntity
    {
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User? User { get; set; }

        [Required]
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }

        public virtual Item? Item { get; set; }
    }
}
