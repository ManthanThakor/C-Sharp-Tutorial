using System;
using System.Threading;

public class ThreadExample
{
    // Method to be executed by each thread
    public static void Task()
    {
        // Display the name of the current thread
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} is starting.");

        // Perform a simple loop to simulate work
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.Name}: {i}"); // Show current thread and iteration
            Thread.Sleep(500); // Pause the thread for 500ms to simulate processing
        }

        // Notify when the thread has completed its task
        Console.WriteLine($"Thread {Thread.CurrentThread.Name} is finished.");
    }

    public static void Main()
    {
        // Create two threads and assign the Task method for execution
        Thread t1 = new Thread(Task); // Thread t1 will run the Task method
        Thread t2 = new Thread(Task); // Thread t2 will also run the Task method

        // Set names for the threads to identify them easily
        t1.Name = "Worker-1";
        t2.Name = "Worker-2";

        // Start the threads to begin execution
        t1.Start(); // Start execution of t1
        t2.Start(); // Start execution of t2

        // Use Join to ensure the main thread waits for the worker threads to complete
        t1.Join(); // Wait for t1 to complete before continuing
        t2.Join(); // Wait for t2 to complete before continuing

        // Notify that the main thread has finished its work
        Console.WriteLine("Main thread finished.");
        Console.ReadLine();
    }
}
