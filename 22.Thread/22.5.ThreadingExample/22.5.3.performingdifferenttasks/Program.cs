using System;
using System.Threading;

public class MyThread
{
    // This method will be executed by the first thread
    public static void Thread1()
    {
        Console.WriteLine("task one");  // Print "task one"
    }

    // This method will be executed by the second thread
    public static void Thread2()
    {
        Console.WriteLine("task two");  // Print "task two"
    }
}

public class ThreadExample
{
    public static void Main()
    {
        // Create two threads, each running a different static method
        // The ThreadStart delegate is used to specify the method to be executed by each thread
        Thread t1 = new Thread(new ThreadStart(MyThread.Thread1));
        Thread t2 = new Thread(new ThreadStart(MyThread.Thread2));

        // Start both threads
        t1.Start();  // Start the first thread to run Thread1 method
        t2.Start();  // Start the second thread to run Thread2 method
        Console.ReadLine();
    }
}
