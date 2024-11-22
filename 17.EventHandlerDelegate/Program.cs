using System;

namespace EventHandlerExample
{
    // Publisher class
    public class Publisher
    {
        // Declare the event using EventHandler delegate
        public event EventHandler Notify;
        // Method to raise the event
        public void RaiseEvent()
        {
            // Raise the event, passing 'this' as sender and null for event arguments
            Notify?.Invoke(this, EventArgs.Empty);
        }
    }

    // Subscriber class
    public class Subscriber
    {
        // Method to handle the event
        public void OnNotify(object sender, EventArgs e)
        {
            Console.WriteLine("Event received! The sender is: " + sender.GetType().Name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Event Handler Delegetes: Using EventHandler with No Custom Data\r\n");

            // Create instances of Publisher and Subscriber 
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();

            // Subscribe to the event
            publisher.Notify += subscriber.OnNotify;

            // Raise the event
            publisher.RaiseEvent();

            Console.ReadLine();
        }
    }
}
