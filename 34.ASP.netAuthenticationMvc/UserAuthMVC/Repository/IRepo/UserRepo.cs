using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UserAuthMVC.EFcore;
using UserAuthMVC.Models;
using UserAuthMVC.Models.ViewModels;
using UserAuthMVC.Provider.IRepository;

namespace UserAuthMVC.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly CookieContext _context;

        public UserRepo(CookieContext context)
        {
            _context = context;
        }

        public CookieUserItem Register(Register model)
        {

            string salt = GenerateSalt();


            string hashedPassword = HashPassword(model.Password, salt);

            var user = new CookieUser
            {
                Id = Guid.NewGuid(),
                Name = model.EmailAddress.Split('@')[0],
                PasswordHash = hashedPassword,
                Salt = salt,
                CreatedUtc = DateTime.UtcNow
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new CookieUserItem
            {
                UserId = user.Id,
                Name = user.Name,
                EmailAddress = model.EmailAddress,
                CreatedUtc = user.CreatedUtc
            };
        }

        public CookieUserItem Validate(Login model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Name == model.EmailAddress);
            if (user == null) return null;

            // Verify password
            string hashedInputPassword = HashPassword(model.Password, user.Salt);
            if (hashedInputPassword != user.PasswordHash) return null;

            return new CookieUserItem
            {
                UserId = user.Id,
                Name = user.Name,
                EmailAddress = model.EmailAddress,
                CreatedUtc = user.CreatedUtc
            };
        }

        private string GenerateSalt(int size = 32)
        {
            using var rng = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[size];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private string HashPassword(string password, string salt)
        {
            using SHA256 sha256 = SHA256.Create();
            byte[] saltedPassword = Encoding.UTF8.GetBytes(password + salt);
            byte[] hashedBytes = sha256.ComputeHash(saltedPassword);
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
