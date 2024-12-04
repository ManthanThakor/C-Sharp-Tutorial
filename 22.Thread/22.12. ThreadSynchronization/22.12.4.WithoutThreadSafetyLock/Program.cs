using System;
using System.Threading;

class Counter
{
    public int Value = 0;

    public void Increment()
    {
        int temp = Value; // Read the current value
        Thread.Sleep(10); // Simulate a delay to increase the chance of interference
        Value = temp + 1; // Write the incremented value
    }
}

class Program
{
    static void Main(string[] args)
    {
        Counter counter = new Counter();

        Thread t1 = new Thread(counter.Increment);
        Thread t2 = new Thread(counter.Increment);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        Console.WriteLine($"Final Counter Value: {counter.Value}"); // Value may be unpredictable
        Console.ReadLine();
    }
}
