using System;
using Domain.Models;

namespace ClassLibrary1
{
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Debugging User Class ===");

            // Create a new user object
            User user = new User
            {
                Username = "Manthan",
                Email = "manthan@example.com",
                PasswordHash = "hashed_password_here"
            };

            // Print user details
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Password Hash: {user.PasswordHash}");

            Console.WriteLine("=== Debugging Complete ===");
            Console.ReadLine(); // Keep console open
        }
    }
}
