using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        SortedList<string, int> sortedList = new SortedList<string, int>();

        sortedList.Add("Orange", 3);
        sortedList.Add("Apple", 1);
        sortedList.Add("Banana", 2);

        Console.WriteLine("SortedList elements:");
        foreach (KeyValuePair<string, int> kvp in sortedList)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        Console.WriteLine($"\nThe value associated with 'Apple' is {sortedList["Apple"]}");

        if (sortedList.ContainsKey("Banana"))
        {
            Console.WriteLine($"The key 'Banana' exists in the SortedList and the value is  {sortedList["Banana"]}");
        }
        Console.ReadLine();
    }
}
