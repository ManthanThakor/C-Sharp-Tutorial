using System;
using System.Threading;

public class MyThread
{
    // This is the method that will be executed by both threads
    public static void Thread1()
    {
        // Loop to print numbers from 0 to 3
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(i);  // Print the current number
        }
    }
}

public class ThreadExample
{
    public static void Main()
    {
        // Create two threads to execute the Thread1 method from MyThread class
        // These threads will run concurrently
        Thread t1 = new Thread(new ThreadStart(MyThread.Thread1));  // Create the first thread
        Thread t2 = new Thread(new ThreadStart(MyThread.Thread1));  // Create the second thread

        // Start both threads
        t1.Start();  // Start the first thread
        t2.Start();  // Start the second thread

        Console.ReadLine();
    }
}
