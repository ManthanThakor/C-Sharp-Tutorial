using System;
using System.Security.Cryptography;
using System.Text;

public class Test
{
    static void Main()
    {

        string password = "test123"; // Replace with actual password
        string storedHash = "f5Mz98Y8CXnWde53Js16ugiFLpiAo3zzByNyURE/POZyCK4dYNuPJCAjob0GBJJlyJ0JphCuKUsaPHmPVetSIw==";

        string enteredHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));

        Console.WriteLine($"Entered Hash: {enteredHash}");
        Console.WriteLine($"Stored Hash: {storedHash}");

        if (enteredHash == storedHash)
        {
            Console.WriteLine("✅ Password Matched!");
        }
        else
        {
            Console.WriteLine("❌ Password Mismatch!");
        }
    }
}
