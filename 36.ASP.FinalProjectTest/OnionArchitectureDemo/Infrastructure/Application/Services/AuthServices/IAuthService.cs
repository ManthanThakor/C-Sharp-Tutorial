using Infrastructure.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ResponseDto<string>> RegisterUser(RegisterDTO model);
        Task<ResponseDto<string>> LoginUser(LoginDTO model);
        Task<ResponseDto<string>> LogoutUser();
    }
}
