using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebAPI.Middleware.Auth;

namespace WebAPI.Middleware.Auth
{
    public class JWTAuthManager : IJWTAuthManager
    {
        #region Private Variables
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor
        public JWTAuthManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #endregion

        public string GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Issuer"],
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}