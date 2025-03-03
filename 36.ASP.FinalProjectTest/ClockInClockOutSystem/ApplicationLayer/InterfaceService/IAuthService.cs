using ApplicationLayer.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InterfaceService
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterUserAsync(RegisterDto model);
        Task<AuthResponseDto> LoginUserAsync(LoginDto model);
        Task<AuthResponseDto> LogoutUserAsync();
    }
}
