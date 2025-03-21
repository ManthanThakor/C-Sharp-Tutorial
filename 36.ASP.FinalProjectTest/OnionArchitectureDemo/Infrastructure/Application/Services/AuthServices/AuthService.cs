using Domain.Models;
using Infrastructure.Application.Dtos;
using Infrastructure.Application.Services.PasswordServices;
using Infrastructure.Application.Services.TokenServices;
using Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public AuthService(
            IRepository<User> userRepository,
            IPasswordService passwordService,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDTO> RegisterAsync(RegisterDTO registerDto)
        {
            var existingUser = await _userRepository.Find(u => u.Email == registerDto.Email);
            if (existingUser != null)
            {
                return new AuthResponseDTO
                {
                    Message = "User with this email already exists",
                    Token = string.Empty
                };
            }

            var user = new User
            {
                Username = registerDto.Username,
                Email = registerDto.Email,
                PasswordHash = _passwordService.HashPassword(registerDto.Password)
            };

            await _userRepository.Add(user);

            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                Message = "Registration successful"
            };
        }

        public async Task<AuthResponseDTO> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userRepository.Find(u => u.Email == loginDto.Email);
            if (user == null)
            {
                return new AuthResponseDTO
                {
                    Message = "Invalid email or password",
                    Token = string.Empty
                };
            }

            if (!_passwordService.VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return new AuthResponseDTO
                {
                    Message = "Invalid email or password",
                    Token = string.Empty
                };
            }

            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDTO
            {
                Token = token,
                Message = "Login successful"
            };
        }

    }
}















// In a stateless authentication system using JWT tokens,
// we would typically handle logout on the client side by removing the token
