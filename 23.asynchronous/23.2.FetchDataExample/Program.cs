using System;
using System.Threading.Tasks;

namespace FetchDataExample
{
    class FetchData
    {
        // Asynchronous method
        public async  Task<string> FetchDataAsync()
        {
            // Simulate a time-consuming operation
            await Task.Delay(2000);  // Wait for 2 seconds
            return "Hello, World!";
        }
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            FetchData fetchData = new FetchData();
            Console.WriteLine("Fetching data...");

            try
            {
                // Call the asynchronous method
                string data = await fetchData.FetchDataAsync();
                // Display the result
                Console.WriteLine($"Data received: {data}");
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred:{ex.Message}")
            }
     

            Console.WriteLine("Program End");

            Console.ReadLine();
        }
    }
}