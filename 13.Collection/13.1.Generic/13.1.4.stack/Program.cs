using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Stack<string> stack = new Stack<string>();

        stack.Push("First Item");
        stack.Push("Second Item");
        stack.Push("Third Item");

        Console.WriteLine("Top item: " + stack.Peek());

        while (stack.Count > 0)
        {
            Console.WriteLine("Popped item: " + stack.Pop());
        }

        if (stack.Count == 0)
        {
            Console.WriteLine("The stack is now empty.");
        }
=
        Console.ReadLine();
    }
}
