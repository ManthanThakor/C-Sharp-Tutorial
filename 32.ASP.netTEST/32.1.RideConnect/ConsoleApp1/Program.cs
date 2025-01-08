using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Driver driver1 = new Driver(1, "John Doe", "123-456-7890", "Downtown", "Sedan");
        Driver driver2 = new Driver(2, "Jane Smith", "987-654-3210", "Uptown", "SUV");

        Passenger passenger = new Passenger(1, "Alice Johnson", "555-123-4567", "Midtown");
        passenger.PaymentMethods.Add("Credit Card");
        passenger.PaymentMethods.Add("PayPal");

        List<Driver> availableDrivers = new List<Driver> { driver1, driver2 };

        RideManager rideManager = new RideManager(availableDrivers);

        Ride requestedRide = passenger.RequestRide(rideManager, "Midtown", "Airport");

        if (requestedRide != null)
        {
            requestedRide.Driver.AcceptRide(requestedRide);

            rideManager.UpdateRideStatus(requestedRide, "DriverOnTheWay");

            INotificationService smsNotification = new SMSNotification();
            smsNotification.SendNotification(passenger, "Your ride is on the way!");
            smsNotification.SendNotification(requestedRide.Driver, "You have a new ride request!");

            rideManager.UpdateRideStatus(requestedRide, "RideCompleted");

            Console.WriteLine("Choose your payment method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. PayPal");

            int choice = int.Parse(Console.ReadLine());

            IPaymentProcessor paymentProcessor = null;
            if (choice == 1)
            {
                paymentProcessor = new CreditCardProcessor();
            }
            else if (choice == 2)
            {
                paymentProcessor = new PayPalProcessor();
            }

            if (paymentProcessor != null)
            {
                passenger.MakePayment(paymentProcessor, 50.0m);
            }

            smsNotification.SendNotification(passenger, "Payment of $50 has been processed.");
        }

        Console.ReadLine();
    }
}
