using System.ComponentModel.DataAnnotations;

namespace UserAuthMVC.Models.ViewModels
{
    public class Register : Login
    {
        [Required, Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
