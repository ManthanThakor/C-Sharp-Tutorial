using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.TokenServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
