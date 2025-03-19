using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Application.Dtos
{
    public class RegisterDTO
    {
        [SwaggerSchema(Description = "User's unique username")]
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(100, ErrorMessage = "Username cannot exceed 100 characters.")]
        public string Username { get; set; } = string.Empty;

        [SwaggerSchema(Description = "User's email address")]
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; } = string.Empty;

        [SwaggerSchema(Description = "User's password (must contain at least one uppercase letter and one special character)")]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[\W]).{8,}$",
            ErrorMessage = "Password must contain at least one uppercase letter and one special character.")]
        public string Password { get; set; } = string.Empty;

        [SwaggerSchema(Description = "Confirmation password (must match password)")]
        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
