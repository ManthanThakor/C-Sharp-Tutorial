using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}










//✅ Purpose:

//Used to receive login details from the client.
//✅ Why Needed?

//We only need email and password to authenticate, so we don't expose the entire User entity.
