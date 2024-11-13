using System;

namespace ClassesAndObject
{
    // Person class definition
    public class Person
    {
        public string Name;

        public void Introduce(string to)
        {
            Console.WriteLine("Hi {0}, I am {1}", to, Name);
        }
    }
}
