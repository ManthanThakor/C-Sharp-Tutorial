using System;
using System.Threading;

class Counter
{
    private readonly object lockObject = new object();
    public int Value = 0;

    public void Increment()
    {
        lock (lockObject) // Ensures thread safety
        {
            Value++;
        }
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

        Console.WriteLine($"Final Counter Value: {counter.Value}"); // Value will be predictable (2)
        Console.ReadLine();
    }
}
