using System;

class Program
{
    // A method matching Action<string> signature
    static void PrintMessage(string message)
    {
        Console.WriteLine($"Message: {message}");
    }

    // A method matching Action<int, int> signature
    static void PrintSum(int a, int b)
    {
        Console.WriteLine($"The sum of {a} and {b} is {a + b}");
    }

    static void Main()
    {
        Console.WriteLine("Example 1: Named Method with Action<string> and Action<int, int>");
        // Action with one input parameter
        Action<string> action1 = PrintMessage;
        action1("Hello, Action!"); // Output: Message: Hello, Action!

        // Action with two input parameters
        Action<int, int> action2 = PrintSum;
        action2(5, 7); // Output: The sum of 5 and 7 is 12

        Console.WriteLine("\nExample 2: Anonymous Methods with Action<string> and Action<int, int>");
        // Action with one parameter (Anonymous Method)
        Action<string> display = delegate (string name)
        {
            Console.WriteLine($"Hello, {name}!");
        };

        display("Manthan"); // Output: Hello, Manthan!

        // Action with two parameters (Anonymous Method)
        Action<int, int> calculateSum = delegate (int x, int y)
        {
            Console.WriteLine($"Sum: {x + y}");
        };

        calculateSum(10, 20); // Output: Sum: 30

        Console.WriteLine("\nExample 3: Lambda Expressions with Action<string> and Action<int, int>");
        // Action with one parameter
        Action<string> greet = (name) => Console.WriteLine($"Hello, {name}!");

        greet("Manthan"); // Output: Hello, Manthan!

        // Action with two parameters
        Action<int, int> multiply = (a, b) => Console.WriteLine($"Product: {a * b}");

        multiply(3, 4); // Output: Product: 12

        Console.WriteLine("\nExample 4: Action with No Parameters");
        // Action with no parameters
        Action showMessage = () => Console.WriteLine("Hello from Action with no parameters!");

        showMessage(); // Output: Hello from Action with no parameters!
        Console.ReadLine();
    }
}
