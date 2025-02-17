using System.ComponentModel.DataAnnotations;

namespace ProdManage.DTO
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The Password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
