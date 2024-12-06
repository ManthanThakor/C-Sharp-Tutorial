using System;
using System.Threading.Tasks;

namespace RestaurantOrder
{

    class Restaurant
    {
        public string Name { get; set; }

        public Restaurant(string name)
        {
            Name = name;
        }

        public async Task PrepareFoodAsync()
        {
            Console.WriteLine("Preparing your food...");
            await Task.Delay(4000);
            Console.WriteLine("Your food is ready!");
        }

        public async Task PrepareDrinksAsync()
        {
            Console.WriteLine("Preparing your drinks...");
            await Task.Delay(2000);
            Console.WriteLine("Your drinks are ready!");
        }

        public async Task PrepareDessertsAsync()
        {
            Console.WriteLine("Preparing your dessert...");
            await Task.Delay(3000);
            Console.WriteLine("Your dessert is ready!");
        }
    }

    class Program
    {

        static async Task Main(string[] args)
        {
            Console.WriteLine("\nRestaurant Order Example\n");

            Restaurant restaurant = new Restaurant("Tasty Treats");

            Console.WriteLine($"Welcome to The {restaurant.Name}\n");

            var foodTask = restaurant.PrepareFoodAsync();
            var drinksTask = restaurant.PrepareDrinksAsync();
            var dessertsTask = restaurant.PrepareDessertsAsync();

            await Task.WhenAll(foodTask, drinksTask, dessertsTask);

            Console.WriteLine("Your order is complete! Enjoy your meal.");

            Console.ReadLine();
        }
    }
}