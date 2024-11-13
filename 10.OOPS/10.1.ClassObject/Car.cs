using System;

namespace ClassesAndObject
{
    // Car class definition
    public class Car
    {
        // Properties (fields)
        public string carName;
        public string Model;
        public int Year;

        // Method to start the engine
        public void StartEngine()
        {
            Console.WriteLine("The engine is started.");
        }

        // Method to drive the car
        public void Drive()
        {
            Console.WriteLine("The car is moving.");
        }

        // Method to provide car information
        public string CarInfo(string name, string model, int year)
        {
            string result = $"Hello, show my car {name}, my car model is {model}, I bought this car in {year}";
            return result;
        }
    }
}
