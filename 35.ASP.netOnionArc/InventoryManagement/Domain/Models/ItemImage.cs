using Domain.CommonEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class ItemImage : BaseEntity
    {
        [Required]
        [Url]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Item")]
        public Guid ItemId { get; set; }

        public virtual Item? Item { get; set; }
    }
}
