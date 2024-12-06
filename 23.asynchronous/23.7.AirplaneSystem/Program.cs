using System;
using System.Threading.Tasks;

namespace AirplaneSystem
{
    class Airplane
    {
        public string FlightNumber { get; set; }
        public string Destination { get; set; }

        public Airplane(string flightNumber, string destination)
        {
            FlightNumber = flightNumber;
            Destination = destination;
        }

        // Simulate Pre-flight checks
        public async Task PerformPreFlightChecks()
        {
            Console.WriteLine($"Flight {FlightNumber}: Performing pre-flight checks...");
            await Task.Delay(5000); 
            Console.WriteLine($"Flight {FlightNumber}: Pre-flight checks completed!");
        }

        // Simulate Boarding passengers 
        public async Task BoardPassengers()
        {
            Console.WriteLine($"Flight {FlightNumber}: Boarding passengers...");
            await Task.Delay(10000); 
            Console.WriteLine($"Flight {FlightNumber}: All passengers boarded!");
        }

        // Simulate Takeoff
        public async Task TakeOff()
        {
            Console.WriteLine($"Flight {FlightNumber}: Preparing for takeoff...");
            await Task.Delay(3000); 
            Console.WriteLine($"Flight {FlightNumber}: Takeoff successful!");
        }

        // Simulate Flight 
        public async Task Fly()
        {
            Console.WriteLine($"Flight {FlightNumber}: Flying to {Destination}...");
            await Task.Delay(15000); 
            Console.WriteLine($"Flight {FlightNumber}: Arrived at {Destination}!");
        }

        // Simulate Landing 
        public async Task Land()
        {
            Console.WriteLine($"Flight {FlightNumber}: Preparing to land...");
            await Task.Delay(5000); 
            Console.WriteLine($"Flight {FlightNumber}: Landing successful!");
        }

    }
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Airplane System Simulation\n");

            var airplane = new Airplane("AA123", "New York");
            // Perform all airplane operations asynchronously
            await airplane.PerformPreFlightChecks();
            await airplane.BoardPassengers();
            await airplane.TakeOff();
            await airplane.Fly();
            await airplane.Land();

            Console.WriteLine("\nFlight complete!");
            Console.ReadLine();
        }
    }
}