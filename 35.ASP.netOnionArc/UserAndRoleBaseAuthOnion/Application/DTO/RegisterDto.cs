using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}








//✅ Purpose:

//Used to receive user registration details.
//✅ Why Needed?

//We don’t expose unnecessary fields like RoleId, RefreshToken, or PasswordHash.
//The password is handled securely before saving.
