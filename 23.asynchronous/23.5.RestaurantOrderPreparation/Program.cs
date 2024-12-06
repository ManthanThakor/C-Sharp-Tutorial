using System;
using System.Threading.Tasks;

namespace RestaurantOrder
{
    // Restaurant class that simulates food, drink, and dessert preparation
    class Restaurant
    {
        public string Name { get; set; }

        // Constructor to set the restaurant name
        public Restaurant(string name)
        {
            Name = name;
        }

        // Simulate an async operation to prepare food
        public async Task PrepareFoodAsync()
        {
            Console.WriteLine("Preparing your food..."); // Notify the user that food preparation has started
            await Task.Delay(4000);  // Simulate food preparation time (4 seconds)
            Console.WriteLine("Your food is ready!"); // Notify the user that food preparation is complete
        }

        // Simulate an async operation to prepare drinks
        public async Task PrepareDrinksAsync()
        {
            Console.WriteLine("Preparing your drinks..."); // Notify the user that drink preparation has started
            await Task.Delay(2000);  // Simulate drink preparation time (2 seconds)
            Console.WriteLine("Your drinks are ready!"); // Notify the user that drink preparation is complete
        }

        // Simulate an async operation to prepare desserts
        public async Task PrepareDessertsAsync()
        {
            Console.WriteLine("Preparing your dessert..."); // Notify the user that dessert preparation has started
            await Task.Delay(3000);  // Simulate dessert preparation time (3 seconds)
            Console.WriteLine("Your dessert is ready!"); // Notify the user that dessert preparation is complete
        }
    }

    // Program class that contains the Main method
    class Program
    {
        // Main method where execution starts
        static async Task Main(string[] args)
        {
            Console.WriteLine("\nRestaurant Order Example\n");

            // Create an instance of the Restaurant class
            Restaurant restaurant = new Restaurant("Tasty Treats");

            // Welcome message to the user
            Console.WriteLine($"Welcome to The {restaurant.Name}\n");

            // Start preparing food, drinks, and desserts concurrently
            var foodTask = restaurant.PrepareFoodAsync(); // Start food preparation
            var drinksTask = restaurant.PrepareDrinksAsync(); // Start drink preparation
            var dessertsTask = restaurant.PrepareDessertsAsync(); // Start dessert preparation

            // Wait for all tasks (food, drinks, desserts) to complete before proceeding
            await Task.WhenAll(foodTask, drinksTask, dessertsTask);

            // Notify the user that the entire order is ready and complete
            Console.WriteLine("Your order is complete! Enjoy your meal.");

            // Keep the console window open so the user can see the output
            Console.ReadLine();
        }
    }
}
