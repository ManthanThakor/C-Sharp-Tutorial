using System;

namespace PrototypePattern
{
    // Prototype
    public abstract class Prototype
    {
        public abstract Prototype Clone();
    }

    // Concrete Prototype
    public class ConcretePrototype : Prototype
    {
        public string Name { get; set; }

        public ConcretePrototype(string name)
        {
            Name = name;
        }

        public override Prototype Clone()
        {
            // Shallow copy (for simple objects)
            return (Prototype)this.MemberwiseClone();
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            ConcretePrototype prototype1 = new ConcretePrototype("Prototype 1");
            Console.WriteLine($"Original Prototype: {prototype1.Name}");

            // Clone the prototype
            ConcretePrototype clonedPrototype = (ConcretePrototype)prototype1.Clone();
            Console.WriteLine($"Cloned Prototype: {clonedPrototype.Name}");
            Console.ReadLine();
        }
    }
}
