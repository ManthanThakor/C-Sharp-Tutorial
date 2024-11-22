using System;
namespace EventExample
{
    // Publisher class
    public class Publisher
    {
        // Declare the delegate for the event
        public delegate void NotifyEventHandler(string message);

        // Declare the event based on the delegate
        public event NotifyEventHandler Notify;

        // Method to raise the event
        public void RaiseEvent(string message)
        {
            // Check if there are subscribers before raising the event
            Notify?.Invoke(message);
        }
    }
    // Subscriber class
    public class Subscriber
    {
        // Method to handle the event
        public void OnNotify(string message)
        {
            Console.WriteLine($"Event received with message: {message}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of publisher and subscriber
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();
            // Subscribe to the event
            publisher.Notify += subscriber.OnNotify;
            // Raise the event
            publisher.RaiseEvent("Hello, Events in C#!");
            // Unsubscribe from the event
            publisher.Notify -= subscriber.OnNotify;
            // Trying to raise the event again (no output since unsubscribed)
            publisher.RaiseEvent("This will not be received.");

            Console.ReadLine();
        }
    }
}
