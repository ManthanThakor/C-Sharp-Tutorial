using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationSystem
{
    public interface INotificationSubject
    {
        void Subscribe(INotificationObserver observer);
        void Unsubscribe(INotificationObserver observer);
        Task NotifyObserversAsync(string message);
    }

    public interface INotificationObserver
    {
        Task UpdateAsync(string message);
    }

    public interface INotification
    {
        Task SendAsync(string recipient, string message);
    }

    public class EmailNotification : INotification
    {
        public async Task SendAsync(string recipient, string message)
        {

            await Task.Delay(3000);
            Console.WriteLine($"Sending Email to {recipient}: {message}");
        }
    }

    public class SMSNotification : INotification
    {
        public async Task SendAsync(string recipient, string message)
        {

            await Task.Delay(3000);
            Console.WriteLine($"Sending SMS to {recipient}: {message}");
        }
    }

    public class NotificationFactory
    {
        public static INotification CreateNotification(string type)
        {
            type = type.ToLower();

            return type switch
            {
                "email" => new EmailNotification(),
                "sms" => new SMSNotification(),
                _ => throw new ArgumentException("Invalid notification type"),
            };
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

        public async Task UpdateAsync(string message)
        {
            var notification = NotificationFactory.CreateNotification(NotificationType);
            await notification.SendAsync(ContactInfo, message);
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

        public async Task NotifyObserversAsync(string message)
        {
            var tasks = new List<Task>();
            foreach (var observer in _observers)
            {
                tasks.Add(observer.UpdateAsync(message));
            }
            await Task.WhenAll(tasks);
        }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var notificationManager = NotificationManager.Instance;

            var customer1 = new Customer("ABC", "email", "ABC@gmail.com");
            var customer2 = new Customer("BCD", "sms", "+1234567890");

            notificationManager.Subscribe(customer1);
            notificationManager.Subscribe(customer2);

            Console.WriteLine("Sending promotional notification...");
            await notificationManager.NotifyObserversAsync("Exclusive Sale! Get 20% off on your next purchase.");

            notificationManager.Unsubscribe(customer1);

            Console.WriteLine("\nSending another notification...");
            await notificationManager.NotifyObserversAsync("Hurry! Free shipping on orders above 30000 INR.");

            Console.ReadLine();
        }
    }
}