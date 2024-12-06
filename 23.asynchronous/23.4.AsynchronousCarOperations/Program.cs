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
            await Task.Delay(3000); // Simulate engine starting delay
            Console.WriteLine($"The {Name} {Model}'s engine is now running.");
        }

        // Simulate an async operation for driving the car
        public async Task Drive()
        {
            Console.WriteLine($"Driving the {Name} {Model}...");
            await Task.Delay(5000); // Simulate the drive delay
            Console.WriteLine($"The {Name} {Model} has reached its destination.");
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("\nCar Operation Example\n");

            Car car = new Car("Toyota", "Camry");

            // First, start the engine and wait for it to complete
            await car.StartEngine();

            // Then, drive the car
            await car.Drive();

            Console.WriteLine("Both tasks are complete.");
            Console.ReadLine(); // Keep the console open
        }
    }
}
