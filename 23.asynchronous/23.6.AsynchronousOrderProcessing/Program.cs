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
            await Task.Delay(PreparationTime); 
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
                new Order(1, "Burger", 3000),     
                new Order(2, "Pizza", 5000),      
                new Order(3, "Pasta", 4000),       
                new Order(4, "Salad", 2000),     
                new Order(5, "Milkshake", 1000),   
            };
            Console.WriteLine("Orders received, starting preparation...\n");

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
