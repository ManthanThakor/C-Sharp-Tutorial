﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Application.Services.PasswordServices
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            string hashedInputPassword = HashPassword(password);

            return string.Equals(hashedInputPassword, passwordHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
