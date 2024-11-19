using System;
using System.Collections.Generic;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class Program
{
    public static void Main()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        numbers.Add(6);
        numbers.AddRange(new int[] { 7, 8 });

        numbers.Remove(3);        
        numbers.RemoveAt(0);     

        Console.WriteLine("List of numbers:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine();

        List<Person> people = new List<Person>
        {
            new Person("Alice", 30),
            new Person("Bob", 25),
            new Person("Charlie", 35)
        };

        people.Add(new Person("Daisy", 40));

        Console.WriteLine("List of people:");
        foreach (Person person in people)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
        Console.ReadLine();
    }
}
