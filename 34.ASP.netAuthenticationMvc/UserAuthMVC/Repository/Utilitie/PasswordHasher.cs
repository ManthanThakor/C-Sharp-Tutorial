using System;
using System.Security.Cryptography;
using System.Text;

namespace UserAuthMVC.Repository.Utilities
{
    public static class PasswordHasher
    {
        private const int SaltSize = 32;
        private const int HashSize = 64;
        private const int Iterations = 10000;

        public static string GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] saltBytes = new byte[SaltSize];
                rng.GetBytes(saltBytes);
                return Convert.ToBase64String(saltBytes);
            }
        }

        public static string HashPassword(string password, string salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), Iterations, HashAlgorithmName.SHA512))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string inputPassword, string storedHash, string salt)
        {
            string newHash = HashPassword(inputPassword, salt);
            return newHash == storedHash;
        }
    }
}
