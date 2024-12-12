using System;
using System.Collections.Generic;
using System.Threading;

namespace NotificationSystem
{
    // Observer Pattern Interfaces
    public interface INotificationSubject
    {
        void Subscribe(INotificationObserver observer);
        void Unsubscribe(INotificationObserver observer);
        void NotifyObservers(string message);
    }

    public interface INotificationObserver
    {
        void Update(string message);
    }

    // Factory Pattern Interface
    public interface INotification
    {
        void Send(string recipient, string message);
    }

    // Concrete notification types (SMS, Email)
    public class EmailNotification : INotification
    {
        public void Send(string recipient, string message)
        {
            // Simulate delay and send email notification
            Console.WriteLine($"Sending Email to {recipient}: {message}");
        }
    }

    public class SMSNotification : INotification
    {
        public void Send(string recipient, string message)
        {
            // Simulate delay and send SMS notification
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
        }
    }

    // Notification Factory Pattern to create notifications
    public class NotificationFactory
    {
        public static INotification CreateNotification(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "email":
                    return new EmailNotification();
                case "sms":
                    return new SMSNotification();
                default:
                    throw new ArgumentException("Invalid notification type");
            }
        }
    }

    // Customer (Observer) class
    public class Customer : INotificationObserver
    {
        public string Name { get; set; }
        public string NotificationType { get; set; }
        public string ContactInfo { get; set; }

        public Customer(string name, string notificationType, string contactInfo)
        {
            Name = name;
            NotificationType = notificationType;
            ContactInfo = contactInfo;
        }

        // Update method will be called to notify the customer
        public void Update(string message)
        {
            var notification = NotificationFactory.CreateNotification(NotificationType);

            // Simulate delay before sending notification
            Thread.Sleep(2000);  // Simulate 2 seconds delay before sending notification

            // Use a new thread to send notification concurrently
            Thread notificationThread = new Thread(() =>
            {
                notification.Send(ContactInfo, message);
                Console.WriteLine($"Notification sent to {Name} via {NotificationType}");
            });
            notificationThread.Start();
            notificationThread.Join();  // Wait for this thread to finish before continuing
        }
    }

    // Singleton Notification Manager (Subject)
    public class NotificationManager : INotificationSubject
    {
        private static NotificationManager _instance;
        private readonly List<INotificationObserver> _observers = new();

        private NotificationManager() { }

        public static NotificationManager Instance => _instance ??= new NotificationManager();

        public void Subscribe(INotificationObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(INotificationObserver observer)
        {
            _observers.Remove(observer);
        }

        // Notify all observers using multithreading
        public void NotifyObservers(string message)
        {
            foreach (var observer in _observers)
            {
                // Each observer's update will be called on a new thread
                Thread observerThread = new Thread(() =>
                {
                    // Simulate some delay before notifying
                    Thread.Sleep(1000);  // Simulate 1 second delay before notifying the observer
                    observer.Update(message);
                });
                observerThread.Start();
                observerThread.Join();  // Ensure threads are executed in order
            }
        }
    }

    // Main Program
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get the singleton instance of NotificationManager
            var notificationManager = NotificationManager.Instance;

            // Create customers with different preferences
            var customer1 = new Customer("ABC", "email", "ABC@gmail.com");
            var customer2 = new Customer("BCD", "sms", "+1234567890");

            // Subscribe customers to notifications
            notificationManager.Subscribe(customer1);
            notificationManager.Subscribe(customer2);

            // Send the first promotional notification
            Console.WriteLine("Sending promotional notification...");
            notificationManager.NotifyObservers("Exclusive Sale! Get 20% off on your next purchase.");

            // Unsubscribe customer1 and send another notification
            notificationManager.Unsubscribe(customer1);
            Console.WriteLine("\nSending another notification...");
            notificationManager.NotifyObservers("Hurry! Free shipping on orders above 5000 INR.");

            Console.ReadLine();
        }
    }
}
