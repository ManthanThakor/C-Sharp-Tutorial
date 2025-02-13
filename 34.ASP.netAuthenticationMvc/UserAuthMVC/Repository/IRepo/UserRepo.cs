using UserAuthMVC.EFcore;
using UserAuthMVC.Models.ViewModels;
using UserAuthMVC.Models;
using UserAuthMVC.Repository.Utilities;

namespace UserAuthMVC.Repository.IRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly CookieContext _context;

        public UserRepo(CookieContext context)
        {
            _context = context;
        }

        // Register user
        public CookieUserItem Register(Register model)
        {
            // Generate a salt for the password
            string salt = PasswordHasher.GenerateSalt();

            // Hash the password with the generated salt
            string hashedPassword = PasswordHasher.HashPassword(model.Password, salt);

            // Create the user
            var user = new CookieUser
            {
                Id = Guid.NewGuid(),
                EmailAddress = model.EmailAddress,
                Name = model.Name,
                PasswordHash = hashedPassword,
                Salt = salt
            };

            // Save the user to the database
            _context.Users.Add(user);
            _context.SaveChanges();

            return new CookieUserItem
            {
                UserId = user.Id,
                EmailAddress = user.EmailAddress,
                Name = user.Name,
                CreatedUtc = user.CreatedUtc
            };
        }

        public CookieUserItem Validate(Login model)
        {
            var user = _context.Users.SingleOrDefault(u => u.EmailAddress == model.EmailAddress);

            if (user == null)
            {
                return null;
            }

            bool isPasswordValid = PasswordHasher.VerifyPassword(model.Password, user.PasswordHash, user.Salt);

            if (!isPasswordValid)
            {
                return null;
            }

            return new CookieUserItem
            {
                UserId = user.Id,
                EmailAddress = user.EmailAddress,
                Name = user.Name,
                CreatedUtc = user.CreatedUtc
            };
        }
    }

}
