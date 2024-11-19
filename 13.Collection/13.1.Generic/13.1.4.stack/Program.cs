using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // Create a stack of strings
        Stack<string> stack = new Stack<string>();

        // Pushing elements onto the stack
        stack.Push("First Item");
        stack.Push("Second Item");
        stack.Push("Third Item");

        // Peek at the top item without removing it
        Console.WriteLine("Top item: " + stack.Peek());

        // Pop elements from the stack
        while (stack.Count > 0)
        {
            Console.WriteLine("Popped item: " + stack.Pop());
        }

        // Check if the stack is empty
        if (stack.Count == 0)
        {
            Console.WriteLine("The stack is now empty.");
        }
    }
}
