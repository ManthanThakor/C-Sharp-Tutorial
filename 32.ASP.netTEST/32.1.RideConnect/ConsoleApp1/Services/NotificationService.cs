using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public interface INotificationService
    {
        void SendNotification(User user, string message);
    }

    public class SMSNotification : INotificationService
    {
        public void SendNotification(User user, string message)
        {
            Console.WriteLine($"Sending SMS to {user.Name}: {message}");
        }
    }

    public class EmailNotification : INotificationService
    {
        public void SendNotification(User user, string message)
        {
            Console.WriteLine($"Sending Email to {user.Name}: {message}");
        }
    }

    public class PushNotification : INotificationService
    {
        public void SendNotification(User user, string message)
        {
            Console.WriteLine($"Sending Push Notification to {user.Name}: {message}");
        }
    }

}
