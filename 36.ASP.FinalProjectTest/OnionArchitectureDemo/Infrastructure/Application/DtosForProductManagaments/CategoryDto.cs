using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Application.DtosForProductManagaments
{
    public class CategoryDto
    {
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string CategoryName { get; set; } = string.Empty;
    }

    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string CategoryName { get; set; } = string.Empty;
    }

    public class UpdateCategoryDto
    {
        [Required(ErrorMessage = "Category ID is required.")]
        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [MaxLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
