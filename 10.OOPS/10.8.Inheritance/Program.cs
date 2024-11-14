using System;

namespace InheritanceExamples
{
    // Base class
    class Animal
    {
        public virtual void Speak()
        {
            Console.WriteLine("Animal makes a sound");
        }

        public void Eat()
        {
            Console.WriteLine("Animal is eating");
        }

        public void Sleep()
        {
            Console.WriteLine("Animal is sleeping");
        }
    }

    // Derived class demonstrating simple inheritance and method overriding
    class Dog : Animal
    {
        public override void Speak()
        {
            base.Speak(); // Calling base class method
            Console.WriteLine("Dog barks");
        }

        public void Bark()
        {
            Console.WriteLine("Dog is barking");
        }
    }

    // Another derived class for hierarchical inheritance
    class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine("Cat meows");
        }

        public void Meow()
        {
            Console.WriteLine("Cat is meowing");
        }
    }

    // Derived class demonstrating multilevel inheritance
    class Labrador : Dog
    {
        public void Fetch()
        {
            Console.WriteLine("Labrador is fetching the ball");
        }
    }

    // Sealed class to prevent further inheritance
    sealed class SealedDog : Dog
    {
        public override void Speak()
        {
            Console.WriteLine("SealedDog barks differently");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Simple inheritance and method overriding example
            Dog myDog = new Dog();
            myDog.Eat();  // Inherited method from Animal
            myDog.Speak(); // Overridden method in Dog
            myDog.Bark(); // Method from Dog class

            Console.WriteLine(); // Separator for output clarity

            // Hierarchical inheritance example
            Cat myCat = new Cat();
            myCat.Sleep(); // Inherited method from Animal
            myCat.Speak(); // Overridden method in Cat
            myCat.Meow(); // Method from Cat class

            Console.WriteLine(); // Separator for output clarity

            // Multilevel inheritance example
            Labrador myLabrador = new Labrador();
            myLabrador.Eat();   // Inherited from Animal
            myLabrador.Bark();  // Inherited from Dog
            myLabrador.Fetch(); // Method from Labrador class

            Console.WriteLine(); // Separator for output clarity

            // Demonstrating sealed class usage
            SealedDog mySealedDog = new SealedDog();
            mySealedDog.Speak(); // SealedDog's overridden Speak method

            Console.ReadLine();
        }
    }
}
