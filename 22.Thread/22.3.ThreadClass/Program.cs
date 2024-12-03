using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // Creating a new thread and passing the method to be executed by the thread
        Thread newThread = new Thread(new ThreadStart(DoWork));
//        new Thread(new ThreadStart(DoWork)); is more explicit.
//new Thread(DoWork); is a shortened version that works the same way, thanks to C# handling the delegate creation behind the scenes.
        //Thread newThread = new Thread(DoWork);

        // Starting the thread
        newThread.Start();
        // Main thread continues execution
        Console.WriteLine("Main thread is running");
        Console.ReadLine();
    }
    // Method to be executed by the new thread
    static void DoWork()
    {
        Console.WriteLine("Work is being done on a separate thread");
    }
}
