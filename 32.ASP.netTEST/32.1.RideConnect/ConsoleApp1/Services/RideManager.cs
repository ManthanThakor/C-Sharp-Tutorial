using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Services
{
    public class RideManager
    {

        private List<Driver> availableDrivers;
        private List<Ride> activeRides;
        private INotificationService notificationService;

        public RideManager(List<Driver> availableDrivers, INotificationService notificationService)
        {
            this.availableDrivers = availableDrivers;
            this.activeRides = new List<Ride>();
            this.notificationService = notificationService;
        }

        public Ride RequestRide(Passenger passenger, string pickupLocation, string dropLocation)
        {
            Driver matchedDriver = availableDrivers.FirstOrDefault(driver => driver.AvailabilityStatus);

            if (matchedDriver != null)
            {
                Ride newRide = new Ride(activeRides.Count + 1, passenger, pickupLocation, dropLocation)
                {
                    Driver = matchedDriver
                };

                activeRides.Add(newRide);
                Console.WriteLine($"Ride requested: {pickupLocation} to {dropLocation}");

                notificationService.SendNotification(matchedDriver, $"You have a new ride request from {passenger.Name}. Pickup: {pickupLocation} - Drop: {dropLocation}");
                return newRide;
            }
            else
            {
                Console.WriteLine("No available drivers at the moment.");
                return null;
            }
        }

        public void HandleRideAcceptance(Ride ride, Driver driver, bool accept)
        {
            if (accept)
            {
                driver.AcceptRide(ride);
                notificationService.SendNotification(driver, $"You have accepted Ride ID: {ride.RideId} - {ride.PickupLocation} to {ride.DropLocation}");
                notificationService.SendNotification(ride.Passenger, $"Your ride request has been accepted by {driver.Name}. Pickup: {ride.PickupLocation} - Drop: {ride.DropLocation}");
                UpdateRideStatus(ride, "DriverOnTheWay");
            }
            else
            {
                driver.DeclineRide(ride);
                notificationService.SendNotification(driver, $"You have declined Ride ID: {ride.RideId}.");
                notificationService.SendNotification(ride.Passenger, $"Your ride request was declined. We are looking for another driver.");

                Driver nextBestDriver = availableDrivers.FirstOrDefault(d => d.AvailabilityStatus && d != driver);

                if (nextBestDriver != null)
                {
                    ride.Driver = nextBestDriver;
                    notificationService.SendNotification(nextBestDriver, $"You have a new ride request from {ride.Passenger.Name}. Pickup: {ride.PickupLocation} - Drop: {ride.DropLocation}");
                    Console.WriteLine($"Ride has been reassigned to driver: {nextBestDriver.Name}");
                    UpdateRideStatus(ride, "DriverAssigned");
                }
                else
                {
                    Console.WriteLine("No available drivers left.");
                }
            }
        }


        public void UpdateRideStatus(Ride ride, string status)
        {
            ride.Status = status;
            Console.WriteLine($"Ride {ride.RideId} status updated to: {status}");
        }
    }
}
