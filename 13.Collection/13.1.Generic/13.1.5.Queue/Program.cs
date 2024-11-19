using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Queue<string> queue = new Queue<string>();

        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");

        Console.WriteLine("Queue contents:");
        foreach (string item in queue)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\nDequeueing elements...");
        while (queue.Count > 0)
        {
            string dequeuedItem = queue.Dequeue();
            Console.WriteLine($"Dequeued: {dequeuedItem}");
        }

        Console.WriteLine($"\nIs the queue empty? {queue.Count == 0}");

        Console.ReadLine();
    }
}
