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
        string GenerateJwtToken(User user);
        bool ValidateToken(string token);
    }
}
