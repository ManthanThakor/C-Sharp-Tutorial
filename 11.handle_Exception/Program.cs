using System;

class Program
{
    static void Main()
    {
        try
        {
            // Code that may cause an exception
        int num1;
        Console.WriteLine("Enter the number:");
        num1 = Convert.ToInt32(Console.ReadLine());

        int num2;
        Console.WriteLine("Enter the second number:");
        num2 = Convert.ToInt32(Console.ReadLine());

        int result = num1 / num2; // This will cause a DivideByZeroException
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Cannot divide by zero: " + ex.Message);
        }
        catch (Exception ex)
        {
            // This catch block handles any other exceptions
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("This code runs no matter what happens.");
        }

        Console.ReadLine();
    }
}
