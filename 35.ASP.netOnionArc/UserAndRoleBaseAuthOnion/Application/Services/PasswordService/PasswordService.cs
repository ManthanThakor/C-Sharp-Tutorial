using System;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services.PasswordService
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            using var hmac = new HMACSHA512();
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash);
        }

        public bool VerifyPassword(string password, string storedHash)
        {
            using var hmac = new HMACSHA512();
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hash) == storedHash;
        }
    }
}
