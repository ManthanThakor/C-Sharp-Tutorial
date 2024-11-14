using System;
using MathOperations; // Importing Calculator namespace
using AnimalKingdom;  // Importing Animal namespace

class Program
{
    static void Main()
    {
        // Using Calculator class from MathOperations namespace
        // ====================================================
        // 1.Compile - time Polymorphism(Method Overloading)
        // ====================================================

        Calculator calc = new Calculator();
        Console.WriteLine("Calculator Examples:");
        Console.WriteLine(calc.Add(5));           // Calls method with one int parameter
        Console.WriteLine(calc.Add(5, 100));       // Calls method with two int parameters
        Console.WriteLine(calc.Add(5.5, 3.3));    // Calls method with double parameters
        Console.WriteLine();

        // Using Animal classes from AnimalKingdom namespace
        // ====================================================
        //2. Runtime Polymorphism (Method Overriding)
        // ====================================================

        Console.WriteLine("Animal Examples:");

        Animal myAnimal = new Dog();
        myAnimal.Speak(); // Calls Dog's Speak method

        myAnimal = new Cat();
        myAnimal.Speak(); // Calls Cat's Speak method

        Console.ReadLine();
    }
}
