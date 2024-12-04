using System;
using System.Threading;

public class MyThread
{
    // Method to be executed by both threads
    public void Thread1()
    {
        // Loop to print numbers from 0 to 9
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine($"Count : {i}");  // Print the current number
        }
    }
}

public class ThreadExample
{
    public static void Main()
    {
        // Create an instance of the MyThread class
        MyThread mt = new MyThread();

        // Create two threads that will both execute the Thread1 method of the MyThread instance
        // The ThreadStart delegate is used to specify the method to be executed by the thread
        Thread t1 = new Thread(new ThreadStart(mt.Thread1));
        Thread t2 = new Thread(new ThreadStart(mt.Thread1));

        // Start both threads. They will run the Thread1 method concurrently.
        t1.Start();
        t1.Join();
        t2.Start();
 
        t2.Join();
        Console.ReadLine();
    }
}
