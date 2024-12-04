using System;
using System.Threading;

public class MyThread
{
    public void Thread1()
    {
        try
        {
            Console.WriteLine("Thread started...");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread running: {i}");
                Thread.Sleep(500); // Simulate some work
            }
            Console.WriteLine("Thread finished.");
        }
        catch (ThreadAbortException ex)
        {
            Console.WriteLine("Thread aborted!");
        }
        finally
        {
            Console.WriteLine("Cleanup code executed.");
        }
    }
}

public class ThreadExample
{
    public static void Main()
    {
        MyThread mt = new MyThread();
        Thread t1 = new Thread(new ThreadStart(mt.Thread1));  // Create a thread
        t1.Start();  // Start the thread

        // Wait for 2 seconds before aborting the thread
        Thread.Sleep(2000);
        Console.WriteLine("Aborting thread...");
        t1.Abort();  // Abort the thread

        // Wait for the thread to finish
        t1.Join();
        Console.WriteLine("Main thread completed.");

        Console.ReadLine();
    }
}
//Thread started...
//Thread running: 0
//Thread running: 1
//Thread running: 2
//Thread running: 3
//Aborting thread...
//Unhandled exception. Thread running: 4
//System.PlatformNotSupportedException: Thread abort is not supported on this platform.
//   at System.Threading.Thread.Abort()