using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        await MainAsync();
        Console.ReadLine();
    }

    static async Task MainAsync()
    {
        Console.WriteLine("Starting operation...");
        await PerformTaskAsync();
        Console.WriteLine("Operation completed.");
    }

    static async Task PerformTaskAsync()
    {
        await Task.Delay(3000); // Non-blocking delay  
        Console.WriteLine("Task is done!");

    }
}