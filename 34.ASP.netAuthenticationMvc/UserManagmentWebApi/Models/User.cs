using System.ComponentModel.DataAnnotations;

namespace UserManagmentWebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Salt { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
    }
}
