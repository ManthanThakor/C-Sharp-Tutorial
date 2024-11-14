using System;

// Abstract class Animal
abstract class Animal
{
    // Abstract method (no implementation here)
    public abstract void MakeSound();

    // Concrete method (implementation here)
    public void Sleep()
    {
        Console.WriteLine("This animal is sleeping.");
    }
}

// Interface ICanSpeak
interface ICanSpeak
{
    void Speak();
}

// Concrete class Lion that inherits from Animal and implements ICanSpeak
class Lion : Animal, ICanSpeak
{
    // Implementing the abstract method from Animal
    public override void MakeSound()
    {
        Console.WriteLine("Lion says: Roar!");
    }

    // Implementing the Speak method from ICanSpeak interface
    public void Speak()
    {
        Console.WriteLine("Lion is speaking.");
    }
}

// Concrete class Elephant that inherits from Animal
class Elephant : Animal
{
    // Implementing the abstract method from Animal
    public override void MakeSound()
    {
        Console.WriteLine("Elephant says: Trumpet!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of Lion and Elephant
        Animal myLion = new Lion();
        Animal myElephant = new Elephant();

        // Calling the methods
        myLion.MakeSound();     // Output: Lion says: Roar!
        myLion.Sleep();         // Output: This animal is sleeping.

        myElephant.MakeSound(); // Output: Elephant says: Trumpet!
        myElephant.Sleep();     // Output: This animal is sleeping.

        // Using ICanSpeak interface with Lion
        ICanSpeak lionSpeaking = new Lion();
        lionSpeaking.Speak();   // Output: Lion is speaking.

        Console.ReadLine();
    }
}
