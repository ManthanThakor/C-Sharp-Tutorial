using System;

namespace Builder
{
    // Product class representing the Computer
    public class Computer
    {
        public string CPU { get; set; }
        public int RAM { get; set; }
        public int Storage { get; set; }
    }

    // Builder interface for creating a Computer
    public interface IComputerBuilder
    {
        void BuildCPU();
        void BuildRAM();
        void BuildStorage();
        Computer GetComputer();
    }

    // Concrete builder that implements IComputerBuilder
    public class GamingComputerBuilder : IComputerBuilder
    {
        private Computer _computer = new Computer();

        // Build CPU for the gaming computer
        public void BuildCPU() => _computer.CPU = "Intel Core i9";

        // Build RAM for the gaming computer
        public void BuildRAM() => _computer.RAM = 32;  // 32GB RAM

        // Build storage for the gaming computer
        public void BuildStorage() => _computer.Storage = 1024;  // 1TB SSD

        // Return the built computer
        public Computer GetComputer() => _computer;
    }

    // Director class that constructs the Computer using the builder
    public class ComputerDirector
    {
        private readonly IComputerBuilder _computerBuilder;

        public ComputerDirector(IComputerBuilder computerBuilder)
        {
            _computerBuilder = computerBuilder;
        }

        // Method to construct the computer step by step
        public Computer BuildComputer()
        {
            _computerBuilder.BuildCPU();
            _computerBuilder.BuildRAM();
            _computerBuilder.BuildStorage();
            return _computerBuilder.GetComputer();
        }
    }

    // Main class to demonstrate the builder pattern
    class Program
    {
        static void Main(string[] args)
        {
            // Create the builder
            IComputerBuilder builder = new GamingComputerBuilder();

            // Create the director and pass the builder
            ComputerDirector director = new ComputerDirector(builder);

            // Build the computer
            Computer gamingComputer = director.BuildComputer();

            // Output the details of the built computer
            Console.WriteLine("Gaming Computer Built:");
            Console.WriteLine($"CPU: {gamingComputer.CPU}");
            Console.WriteLine($"RAM: {gamingComputer.RAM}GB");
            Console.WriteLine($"Storage: {gamingComputer.Storage}GB SSD");
            Console.ReadLine();
        }
    }
}
