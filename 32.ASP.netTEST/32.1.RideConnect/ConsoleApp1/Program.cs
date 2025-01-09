using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Driver driver1 = new Driver(1, "ABC", "123-456-7890", "Downtown", "Sedan");
        Driver driver2 = new Driver(2, "xyz", "987-654-3210", "Uptown", "SUV");

        Passenger passenger = new Passenger(1, "VVV", "555-123-4567", "Midtown");
        passenger.PaymentMethods.Add("Credit Card");
        passenger.PaymentMethods.Add("PayPal");

        List<Driver> availableDrivers = new List<Driver> { driver1, driver2 };

        INotificationService notificationService = new SMSNotification();

        RideManager rideManager = new RideManager(availableDrivers, notificationService);


        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== Welcome to the Ride Booking System ===");
        Console.ResetColor();
        Console.WriteLine();

        Console.WriteLine("Enter Pickup Location:");
        string pickupLocation = Console.ReadLine();
        Console.WriteLine("Enter Drop Location:");
        string dropLocation = Console.ReadLine();

        Ride requestedRide = passenger.RequestRide(rideManager, pickupLocation, dropLocation);

        if (requestedRide != null)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{requestedRide.Driver.Name}, you have been notified for a ride request.");
            Console.ResetColor();
            Console.WriteLine("Do you want to accept or decline the ride?");
            Console.WriteLine("1. Accept");
            Console.WriteLine("2. Decline");

            int driverChoice = int.Parse(Console.ReadLine());

            if (driverChoice == 1)
            {
                rideManager.HandleRideAcceptance(requestedRide, requestedRide.Driver, true);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Ride accepted by {requestedRide.Driver.Name}.");
                Console.ResetColor();
            }
            else if (driverChoice == 2)
            {
                rideManager.HandleRideAcceptance(requestedRide, requestedRide.Driver, false);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ride declined by {requestedRide.Driver.Name}.");
                Console.ResetColor();
            }

            rideManager.UpdateRideStatus(requestedRide, "RideCompleted");

            Console.WriteLine("\nChoose your payment method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. PayPal");

            int choice = int.Parse(Console.ReadLine());

            IPaymentProcessor paymentProcessor = null;
            if (choice == 1)
            {
                paymentProcessor = new CreditCardProcessor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Credit Card selected.");
            }
            else if (choice == 2)
            {
                paymentProcessor = new PayPalProcessor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PayPal selected.");
            }

            if (paymentProcessor != null)
            {
                Console.ResetColor();
                passenger.MakePayment(paymentProcessor, 50.0m);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Payment processed successfully.");
                Console.ResetColor();
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadLine();
    }
}
