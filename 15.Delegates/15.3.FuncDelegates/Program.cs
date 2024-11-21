using System;

class Program
{
    // A method that matches the Func<int, int, int> signature
    static int Add(int a, int b)
    {
        return a + b;
    }

    // A method that matches Func with no input and a string output
    static string GetMessage()
    {
        return "Hello from Func with 0 inputs!";
    }

    static void Main()
    {
        Console.WriteLine("Example 1: Named Method with Func<int, int, int>");
        // Using a named method with Func
        Func<int, int, int> addFunc = Add;

        int sumResult = addFunc(10, 20);
        Console.WriteLine($"The sum is: {sumResult}"); // Output: The sum is: 30

        Console.WriteLine("\nExample 2: Named Method with Func<string>");
        // Using a Func delegate with no input and a string output
        Func<string> getMessageFunc = GetMessage;

        // Invoke the delegate
        string messageResult = getMessageFunc();
        Console.WriteLine(messageResult); // Output: Hello from Func with 0 inputs!

        Console.WriteLine("\nExample 3: Anonymous Method with Func<int, int, int>");
        // Anonymous method assigned to a Func delegate
        Func<int, int, int> multiply = delegate (int a, int b)
        {
            return a * b;
        };

        // Invoke the Func delegate
        int productResult = multiply(4, 5);
        Console.WriteLine($"The product is: {productResult}"); // Output: The product is: 20

        Console.WriteLine("\nExample 4: Anonymous Method with Func<string>");
        // Another example with no inputs
        Func<string> greet = delegate
        {
            return "Hello from an anonymous method!";
        };

        Console.WriteLine(greet()); // Output: Hello from an anonymous method!
        Console.ReadLine();
    }
}
