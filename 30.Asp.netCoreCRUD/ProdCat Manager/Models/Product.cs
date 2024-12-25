using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdCat_Manager.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        [MaxLength(100, ErrorMessage = "The product name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The price must be greater than zero.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A category must be selected.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
