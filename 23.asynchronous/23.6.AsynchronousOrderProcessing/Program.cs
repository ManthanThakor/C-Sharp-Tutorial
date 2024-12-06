using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderProcessing
{
    class Order
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int PreparationTime { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Order Processing System \n");

            Order order = new Order();
            Console.ReadLine();
        }
    }
}