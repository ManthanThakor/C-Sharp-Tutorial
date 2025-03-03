using ApplicationLayer.DTOS;
using ApplicationLayer.InterfaceService;
using DomainLayer.Entity;
using InfrastructureLayer.Utilities;
using System;
using System.Threading.Tasks;
using InfrastructureLayer.InterfaceRepo;

namespace ApplicationLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;

        public AuthService(IEmployeeRepository employeeRepository, IPasswordService passwordService, ITokenService tokenService)
        {
            _employeeRepository = employeeRepository;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto> RegisterUserAsync(RegisterDto model)
        {
            var existingUser = await _employeeRepository.GetByEmailAsync(model.Email);

            if (existingUser != null)
            {
                return new AuthResponseDto { Message = "User already exists." };

            }

            var user = new Employee
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                PasswordHash = _passwordService.HashPassword(model.Password),
                Role = "Employee"
            };

            await _employeeRepository.AddAsync(user);
            await _employeeRepository.SaveChangesAsync();

            return new AuthResponseDto { Message = "User registered successfully." };
        }

        public async Task<AuthResponseDto> LoginUserAsync(LoginDto model)
        {
            var user = await _employeeRepository.GetByEmailAsync(model.Email);
            if (user == null || !_passwordService.VerifyPassword(model.Password, user.PasswordHash))
            {
                return new AuthResponseDto { Message = "Invalid email or password." };

            }

            var token = _tokenService.GenerateToken(user);

            return new AuthResponseDto { Token = token, Message = "Login successful." };
        }

        public AuthResponseDto LogoutUser()
        {
            return new AuthResponseDto { Message = "User logged out successfully." };
        }
    }
}
