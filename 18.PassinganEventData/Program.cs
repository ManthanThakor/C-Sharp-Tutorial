using System;

namespace EventHandlerWithArgsExample
{
    // Custom event data class
    public class CustomEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    // Publisher class
    public class Publisher
    {
        // Declare the event using EventHandler<TEventArgs>
        public event EventHandler<CustomEventArgs> Notify;

        // Method to raise the event
        public void RaiseEvent(string message)
        {
            // Create a CustomEventArgs object to hold the message
            CustomEventArgs args = new CustomEventArgs { Message = message };
            Notify?.Invoke(this, args);
        }
    }

    // Subscriber class
    public class Subscriber
    {
        // Method to handle the event
        public void OnNotify(object sender, CustomEventArgs e)
        {
            Console.WriteLine($"Event received from {sender.GetType().Name}: {e.Message}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Passing Event Data Event Handler \n");
            // Create instances of Publisher and Subscriber
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber();
            // Subscribe to the event
            publisher.Notify += subscriber.OnNotify;
            // Raise the event with a custom message
            publisher.RaiseEvent("Hello, this is a custom message!");

            Console.ReadLine();
        }
    }
}
