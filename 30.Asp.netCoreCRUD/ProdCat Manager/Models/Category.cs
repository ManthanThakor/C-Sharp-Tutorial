using System.ComponentModel.DataAnnotations;

namespace ProdCat_Manager.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The category name is required.")]
        [MaxLength(50, ErrorMessage = "The category name cannot exceed 50 characters.")]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
