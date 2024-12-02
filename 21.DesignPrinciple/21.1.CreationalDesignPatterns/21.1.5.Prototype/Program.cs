using System;

// The Prototype Interface
public interface IPrototype
{
    IPrototype Clone();
}

// Concrete Prototype Class
public class ConcretePrototype : IPrototype
{
    public string Name { get; set; }
    public int Age { get; set; }

    public ConcretePrototype(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Implement the Clone method
    public IPrototype Clone()
    {
        // Perform a shallow copy
        return new ConcretePrototype(Name, Age);
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}";
    }
}

// Client code
public class Client
{
    public static void Main()
    {
        // Create a concrete prototype object
        ConcretePrototype prototype = new ConcretePrototype("John", 30);

        // Clone the object
        ConcretePrototype clonedObject = (ConcretePrototype)prototype.Clone();

        // Display original and cloned object
        Console.WriteLine("Original Object: " + prototype);
        Console.WriteLine("Cloned Object: " + clonedObject);

        // Modifying cloned object
        clonedObject.Name = "Jane";
        clonedObject.Age = 25;

        // Display after modification
        Console.WriteLine("Modified Cloned Object: " + clonedObject);
        Console.WriteLine("Original Object after modification: " + prototype);
    }
}
