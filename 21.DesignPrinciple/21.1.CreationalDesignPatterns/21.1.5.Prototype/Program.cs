using System;
using System.Collections.Generic;

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
    public List<string> Hobbies { get; set; } // Reference type for demonstration

    public ConcretePrototype(string name, int age, List<string> hobbies)
    {
        Name = name;
        Age = age;
        Hobbies = hobbies;
    }

    // Shallow copy implementation
    public IPrototype Clone()
    {
        // Shallow copy: only the top-level object is copied
        // The list (Hobbies) will not be copied, just referenced.
        return new ConcretePrototype(Name, Age, Hobbies);
    }

    // Deep copy implementation
    public IPrototype DeepClone()
    {
        // Deep copy: both the object and the list are copied.
        return new ConcretePrototype(Name, Age, new List<string>(Hobbies));
    }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Hobbies: {string.Join(", ", Hobbies)}";
    }
}

// Client code
public class Client
{
    public static void Main()
    {
        // Create a concrete prototype object with a list of hobbies
        List<string> hobbies = new List<string> { "Reading", "Swimming" };
        ConcretePrototype prototype = new ConcretePrototype("John", 30, hobbies);

        // Shallow clone
        ConcretePrototype shallowClonedObject = (ConcretePrototype)prototype.Clone();

        // Deep clone
        ConcretePrototype deepClonedObject = (ConcretePrototype)prototype.DeepClone();

        // Display original and cloned objects
        Console.WriteLine("Original Object: " + prototype);
        Console.WriteLine("Shallow Cloned Object: " + shallowClonedObject);
        Console.WriteLine("Deep Cloned Object: " + deepClonedObject);

        // Modify the hobby in the original object
        prototype.Hobbies.Add("Cycling");

        // Display after modification
        Console.WriteLine("\nAfter modifying the Original Object's Hobbies:");
        Console.WriteLine("Original Object: " + prototype);
        Console.WriteLine("Shallow Cloned Object: " + shallowClonedObject);
        Console.WriteLine("Deep Cloned Object: " + deepClonedObject);

        Console.ReadLine();
    }
}
