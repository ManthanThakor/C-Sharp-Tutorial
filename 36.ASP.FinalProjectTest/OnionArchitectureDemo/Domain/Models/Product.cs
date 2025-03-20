using Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{

    public class Product : Base
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();

    }

}
