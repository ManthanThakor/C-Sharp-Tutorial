using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserSer
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
        Task<TokenResponseDto> RefreshTokenAsync(string refreshToken);
        Task<bool> LogoutAsync(); // Removed refreshToken parameter
    }

}
