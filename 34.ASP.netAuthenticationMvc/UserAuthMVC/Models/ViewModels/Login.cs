using System.ComponentModel.DataAnnotations;

namespace UserAuthMVC.Models.ViewModels
{
    public class Login
    {
        [Required, EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
