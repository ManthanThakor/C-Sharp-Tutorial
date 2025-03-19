using System;
using Domain.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Debugging User Class ===");

            User user1 = new User();
            Console.WriteLine(user1.Email); // Output: ""

            User user = new User
            {
                Username = "Manthan",
                Email = "manthan@example.com",
                PasswordHash = "hashed_password_here"
            };

            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Username: {user.Username}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Password Hash: {user.PasswordHash}");

            Console.WriteLine("=== Debugging Complete ===");
            Console.ReadLine();
        }
    }
}
