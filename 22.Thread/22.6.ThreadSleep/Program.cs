using System;
using System.Threading;

public class MyThread
{
    // Method executed by the first thread
    public static void Thread1()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Thread 1: {i}");
            Thread.Sleep(1000); // Pause for 1 second (1000 milliseconds)
        }
    }

    // Method executed by the second thread
    public static void Thread2()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Thread 2: {i}");
            Thread.Sleep(500); // Pause for 0.5 seconds (500 milliseconds)
        }
    }
}

public class ThreadExample
{
    public static void Main()
    {
        // Create two threads
        Thread t1 = new Thread(new ThreadStart(MyThread.Thread1));
        Thread t2 = new Thread(new ThreadStart(MyThread.Thread2));

        // Start both threads
        t1.Start();
        t2.Start();

        // Wait for both threads to finish before the main thread exits
        t1.Join();
        t2.Join();

        Console.WriteLine("Both threads have completed.");

        Console.ReadLine();
    }
}
