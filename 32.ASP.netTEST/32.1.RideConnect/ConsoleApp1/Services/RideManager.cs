using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class RideManager
    {
        private List<Driver> availableDrivers;
        private List<Ride> activeRides;

        public RideManager(List<Driver> availableDrivers)
        {
            this.availableDrivers = availableDrivers;
            this.activeRides = new List<Ride>();
        }

        public Ride RequestRide(Passenger passenger, string pickupLocation, string dropLocation)
        {
            Driver matchedDriver = availableDrivers.FirstOrDefault(driver => driver.AvailabilityStatus);

            if (matchedDriver != null)
            {
                Ride newRide = new Ride(activeRides.Count + 1, passenger, pickupLocation, dropLocation);
                newRide.Driver = matchedDriver;

                activeRides.Add(newRide);

                matchedDriver.AvailabilityStatus = false;

                Console.WriteLine($"Ride requested: {pickupLocation} to {dropLocation}");
                return newRide;
            }
            else
            {
                Console.WriteLine("No available drivers at the moment.");
                return null;
            }
        }

        public void UpdateRideStatus(Ride ride, string status)
        {
            ride.Status = status;
            Console.WriteLine($"Ride {ride.RideId} status updated to: {status}");
        }
    }

}
