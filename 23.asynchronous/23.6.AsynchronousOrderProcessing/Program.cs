using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderProcessing
{
    class Order
    {
        public int OrderId { get; set; }
        public string Item { get; set; }
        public int PreparationTime { get; set; }

        public Order(int orderId, string item, int preparationTime)
        {
            OrderId = orderId;
            Item = item;
            PreparationTime = preparationTime;
        }

        public async Task prepare()
        {
            Console.WriteLine($"Order {OrderId}: Preparing {Item}...");
            await Task.Delay(PreparationTime); // Simulate preparation time
            Console.WriteLine($"Order {OrderId}: {Item} is ready!");
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\nRestaurant Order Processing\n");

            List<Order> order = new List<Order>
            {
                new Order(1, "Burger", 3000),      // Order 1: Burger takes 3 seconds
                new Order(2, "Pizza", 5000),       // Order 2: Pizza takes 5 seconds
                new Order(3, "Pasta", 4000),       // Order 3: Pasta takes 4 seconds
                new Order(4, "Salad", 2000),       // Order 4: Salad takes 2 seconds
                new Order(5, "Milkshake", 1000),   // Order 5: Milkshake takes 1 second
            };
            Console.WriteLine("Orders received, starting preparation...\n");

            // Create a list to store tasks
            var preparationTasks = new List<Task>();
            foreach (var task in order)
            {
                preparationTasks.Add(task.prepare());
            }
            await Task.WhenAll(preparationTasks);

            Console.WriteLine("\nAll orders are ready!");

            Console.ReadLine();
        }
    }
}


//Restaurant Order Processing

//Orders received, starting preparation...

//Order 1: Preparing Burger...
//Order 2: Preparing Pizza...
//Order 3: Preparing Pasta...
//Order 4: Preparing Salad...
//Order 5: Preparing Milkshake...
//Order 5: Milkshake is ready!
//Order 4: Salad is ready!
//Order 1: Burger is ready!
//Order 3: Pasta is ready!
//Order 2: Pizza is ready!

//All orders are ready!
