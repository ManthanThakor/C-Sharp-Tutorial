using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> ageDictionary = new Dictionary<string, int>();

        ageDictionary.Add("John", 30);
        ageDictionary.Add("Alice", 25);
        ageDictionary.Add("Bob", 35);

        Console.WriteLine("John's age: " + ageDictionary["John"]);
        Console.WriteLine("Alice's age: " + ageDictionary["Alice"]);
        Console.WriteLine("Bob's age: " + ageDictionary["Bob"]);

        Console.WriteLine("\nAll entries:");
        foreach (KeyValuePair<string, int> entry in ageDictionary)
        {
            Console.WriteLine(entry.Key + ": " + entry.Value);
        }
    }
}
