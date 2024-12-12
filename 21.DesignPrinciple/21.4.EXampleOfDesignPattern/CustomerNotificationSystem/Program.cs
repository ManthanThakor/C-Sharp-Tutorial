using System;
using System.Collections.Generic;

namespace NotificationSystem
{

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

    public interface INotification
    {
        void Send(string recipient, string message);
    }

    public class EmailNotification : INotification
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"Sending Email to {recipient}: {message}");
        }
    }

    public class SMSNotification : INotification
    {
        public void Send(string recipient, string message)
        {
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
        }
    }

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
        public void Update(string message)
        {
            var notification = NotificationFactory.CreateNotification(NotificationType);
            notification.Send(ContactInfo, message);

        }
    }

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

        public void NotifyObservers(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var notificationManager = NotificationManager.Instance;

            var customer1 = new Customer("ABC", "email", "ABC@gmail.com");
            var customer2 = new Customer("BCD", "sms", "+1234567890");

            notificationManager.Subscribe(customer1);
            notificationManager.Subscribe(customer2);

            Console.WriteLine("Sending promotional notification...");
            notificationManager.NotifyObservers("Exclusive Sale! Get 20% off on your next purchase.");

            notificationManager.Unsubscribe(customer1);

            Console.WriteLine("\nSending another notification...");
            notificationManager.NotifyObservers("Hurry! Free shipping on orders above 5000 INR.");

            Console.ReadLine();
        }
    }

}
//Sending promotional notification...
//Sending Email to ABC@gmail.com: Exclusive Sale! Get 20% off on your next purchase.
//Sending SMS to +1234567890: Exclusive Sale! Get 20% off on your next purchase.

//Sending another notification...
//Sending SMS to +1234567890: Hurry! Free shipping on orders above 5000 INR.

