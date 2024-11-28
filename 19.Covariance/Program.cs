// Delegate with a parameter of type string
delegate void ContravariantDelegate(string message);

class Program
{
    static void PrintObject(obj message)
    {
        Console.WriteLine($"Received: {message}");
    }

    static void Main()
    {
        // Contravariance allows assignment because object is less derived than string
        ContravariantDelegate del = PrintObject;

        del("Hello, Contravariance!"); // Works fine
        Console.ReadLine();
    }
}
