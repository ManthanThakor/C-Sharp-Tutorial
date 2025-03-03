using ApplicationLayer.InterfaceService;
using DomainLayer.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(Employee user)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_config["Jwt:ExpireMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}










































//We use **`JwtRegisteredClaimNames`** instead of **`ClaimTypes`** because **`JwtRegisteredClaimNames`** follows the official **JWT (JSON Web Token) standard**, making the token compatible with other systems, APIs, and services that use JWT.  

//### **Simple Explanation**  
//✅ **`JwtRegisteredClaimNames`** → Standard claim names used in JWT (e.g., `sub`, `email`, `name`).  
//✅ **`ClaimTypes`** → Used mainly in **.NET-based authentication**, not always recognized by other systems.  

//For example:  
//- `JwtRegisteredClaimNames.Email` → Stored as **"email" * * in JWT(recognized globally).
//- `ClaimTypes.Email` → Stored as **"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"`, which is .NET - specific * *and might not work with non-.NET systems.  

//### **Conclusion**  
//Using `JwtRegisteredClaimNames` ensures that your **JWT tokens work across different platforms**, not just in .NET. 🚀


//But in ASP.NET Core, using ClaimTypes.Role is preferred because ASP.NET's role-based authorization system recognizes it automatically.