using System;
using System.Threading.Tasks;

namespace CarOperation
{
    class Car
    {
        public string Name { get; set; }
        public string Model { get; set; }

        public Car(string name, string model)
        {
            Name = name;
            Model = model;
        }

        // Simulate an async operation, such as starting the car

        public async Task StartEngine()
        {
            Console.WriteLine("Starting the engine...");
            await Task.Delay(3000);
            Console.WriteLine($"The {Name} {Model}'s engine is now running.");
        }

        // Simulate an async operation for driving the car

        public async Task Drive()
        {
            Console.WriteLine($"Driving the {Name} {Model}...");
            await Task.Delay(5000);
            Console.WriteLine($"The {Name} {Model} has reached its destination.");
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\n Car Operation Example \n");

            Car car = new Car("Toyota", "Camry");
            await car.StartEngine();
            await car.Drive();

            Console.WriteLine("Both tasks are complete.");
            Console.ReadLine();  
        }
    }
}