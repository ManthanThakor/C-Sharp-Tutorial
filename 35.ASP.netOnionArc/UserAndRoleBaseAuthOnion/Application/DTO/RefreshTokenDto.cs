using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class RefreshTokenDto
    {
        public string RefreshToken { get; set; }
    }
}












//✅ Purpose:

//Used when a user’s JWT token expires and they request a new token using the RefreshToken.
//✅ Why Needed?

//Ensures a stateless authentication system.
//Users don’t have to log in again if their token expires.