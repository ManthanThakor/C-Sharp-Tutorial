using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TokenService
{
    public interface ITokenService
    {
        (string AccessToken, DateTime ExpiresAt) GenerateJwtToken(User user);
        string GenerateRefreshToken();
        bool ValidateToken(string token);
    }
}
