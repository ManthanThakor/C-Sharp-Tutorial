using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}





//✅ Purpose:

//Sent to the client after successful authentication.
//Contains JWT Token, Refresh Token, and user details.
//✅ Why Needed?

//To ensure only relevant data is sent after login.
//The Token is required for authentication.
//The RefreshToken is used for generating new tokens.