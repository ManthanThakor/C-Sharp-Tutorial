using System.ComponentModel.DataAnnotations;

namespace UserAuthMVC.Models.ViewModels
{
    public class Register : Login
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }  // Changed from internal set to public

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
