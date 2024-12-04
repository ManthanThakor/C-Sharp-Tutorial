using System;
using System.Threading;

// Class containing methods to simulate tasks for threading
public class MyThread
{
    // Task1 method to be executed by a thread
    public static void Task1()
    {
        Console.WriteLine("Task 1 starting...");  // Notify that Task 1 has started
        for (int i = 0; i < 5; i++)  // Loop to simulate work
        {
            Console.WriteLine($"Task 1: {i}");  // Print the current iteration of Task 1
            Thread.Sleep(500);  // Pause execution for 500ms to simulate processing
        }
        Console.WriteLine("Task 1 finished.");  // Notify that Task 1 has completed
    }

    // Task2 method to be executed by a thread
    public static void Task2()
    {
        Console.WriteLine("Task 2 starting...");  // Notify that Task 2 has started
        for (int i = 0; i < 5; i++)  // Loop to simulate work
        {
            Console.WriteLine($"Task 2: {i}");  // Print the current iteration of Task 2
            Thread.Sleep(700);  // Pause execution for 700ms to simulate processing
        }
        Console.WriteLine("Task 2 finished.");  // Notify that Task 2 has completed
    }
}

// Main class to execute and demonstrate threading with Join
public class ThreadExample
{
    public static void Main()
    {
        // Create threads to execute Task1 and Task2
        Thread t1 = new Thread(new ThreadStart(MyThread.Task1));  // Create thread for Task1
        Thread t2 = new Thread(new ThreadStart(MyThread.Task2));  // Create thread for Task2

        t1.Start();  // Start thread t1 to execute Task1
        t2.Start();  // Start thread t2 to execute Task2

        // Ensure that the main thread waits for t1 to complete
        t1.Join();  // Block the main thread until t1 completes
        Console.WriteLine("Task 1 has completed. Continuing...");  // Notify after t1 finishes

        // Ensure that the main thread waits for t2 to complete
        t2.Join();  // Block the main thread until t2 completes
        Console.WriteLine("Task 2 has completed. Continuing...");  // Notify after t2 finishes

        Console.WriteLine("Main thread finished.");  // Notify that the main thread has completed

        Console.ReadLine();
    }
}
