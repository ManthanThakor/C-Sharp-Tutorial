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

        // example 2 

        var cities = new Dictionary<string, string>(){
            {"UK", "London, Manchester, Birmingham"},
            {"USA", "Chicago, New York, Washington"},
            {"India", "Mumbai, New Delhi, Pune"}
        };

        cities["UK"] = "Liverpool, Bristol"; // update value of UK key
        cities["USA"] = "Los Angeles, Boston"; // update value of USA key
                                               //cities["France"] = "Paris"; //throws run-time exception: KeyNotFoundException

        if (cities.ContainsKey("France"))
        {
            cities["France"] = "Paris";
        }

        foreach (var kvp in cities)
            Console.WriteLine("Key: {0}, Value:{1}", kvp.Key, kvp.Value);

        Console.ReadLine();
    }

}
