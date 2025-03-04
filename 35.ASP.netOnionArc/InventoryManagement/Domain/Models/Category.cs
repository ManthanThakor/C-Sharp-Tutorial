using Domain.CommonEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
