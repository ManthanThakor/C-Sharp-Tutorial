using Domain.CommonEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryName { get; set; }

        public virtual List<Item> Items { get; set; } = new List<Item>();
    }
}
