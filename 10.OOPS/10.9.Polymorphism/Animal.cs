using System;

namespace AnimalKingdom
{
    public class Animal
    {
        // Base method marked as virtual to allow overriding
        public virtual void Speak()
        {
            Console.WriteLine("Animal makes a sound");
        }
    }

    public class Dog : Animal
    {
        // Overriding the Speak method
        public override void Speak()
        {
            Console.WriteLine("Dog barks");
        }
    }

    public class Cat : Animal
    {
        // Overriding the Speak method
        public override void Speak()
        {
            Console.WriteLine("Cat meows");
        }
    }
}
