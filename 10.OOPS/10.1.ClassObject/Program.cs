
using System;

namespace ClassesAndObject
{
    // Program class with Main method
    class Program
    {
        static void Main(string[] args)
        {


            // =======================
            // Create an instance of Car
            var car = new Car();
            car.carName = "Toyota";
            car.Model = "Corolla";
            car.Year = 2020;

            // Calling methods of the Car object
            Console.WriteLine($"Car: {car.carName} {car.Model}, Year: {car.Year}");
            car.StartEngine();
            car.Drive();
            Console.WriteLine(car.CarInfo(car.carName, car.Model, car.Year));

            // Create an instance of Person
            Person person = new Person();
            person.Name = "John";
            person.Introduce("Mosh");

            // Prevent console window from closing immediately
            Console.ReadLine();
        }
    }
}
