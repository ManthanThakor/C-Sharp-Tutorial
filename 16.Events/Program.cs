using System;

namespace Events
{
    public delegate void Notify();

    public class ProcessBusinessLogic
    {
        // Define an event
        public event Notify OnProcess;

        // Method to invoke the event
        public virtual void OnProcessCompleted()
        {
            OnProcess?.Invoke();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Events \n");

            ProcessBusinessLogic bl = new ProcessBusinessLogic();

            // Subscribe to the event
            bl.OnProcess += Bl_ProcessCompleted;

            // Trigger the process logic, which invokes the event
            bl.OnProcessCompleted();

            Console.ReadLine();
        }

        // Event handler method
        public static void Bl_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }
    }
}
