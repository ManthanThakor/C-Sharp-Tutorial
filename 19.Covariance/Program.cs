using System;
public class InvalidAgeException : Exception
{
    public InvalidAgeException(String message)
        : base(message)
    {

    }
}
public class TestUserDefinedException
{
    static void validate(int age)
    {
        if (age < 18)
        {
            throw new InvalidAgeException("Sorry, Age must be greater than 18");
        }
        else
        {
            Console.WriteLine("WELCOME");
        }
    }
    public static void Main(string[] args)
    {
        try
        {
            validate(22);
        }
        catch (InvalidAgeException e) 
        { 
            Console.WriteLine(e); 
        }
     
        Console.WriteLine("Rest of the code");
        Console.ReadLine();
    }
}