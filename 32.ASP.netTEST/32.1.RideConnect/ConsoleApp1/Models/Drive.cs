using System;

namespace ConsoleApp1.Models
{
    public class Driver : User
    {
        public string VehicleDetails { get; set; }
        public bool AvailabilityStatus { get; set; }

        public Driver(int id, string name, string contactInfo, string location, string vehicleDetails)
            : base(id, name, contactInfo, location)
        {
            VehicleDetails = vehicleDetails;
            AvailabilityStatus = true;
        }

        public void AcceptRide(Ride ride)
        {
            if (AvailabilityStatus)
            {
                ride.Status = "Accepted";
                AvailabilityStatus = false;
                Console.WriteLine($"{Name} has accepted the ride: Ride ID {ride.RideId}, {ride.PickupLocation} to {ride.DropLocation}");
            }
            else
            {
                Console.WriteLine($"{Name} is currently unavailable.");
            }
        }

        public void DeclineRide(Ride ride)
        {
            ride.Status = "Declined";
            Console.WriteLine($"{Name} has declined the ride: Ride ID {ride.RideId}, {ride.PickupLocation} to {ride.DropLocation}");
        }

        public void NotifyRideRequest(Ride ride)
        {
            Console.WriteLine($"{Name}, you have a new ride request! Ride ID: {ride.RideId}, Pickup: {ride.PickupLocation}, Drop: {ride.DropLocation}");
            Console.WriteLine("Do you want to accept or decline the ride?");
            Console.WriteLine("1. Accept");
            Console.WriteLine("2. Decline");
        }
    }
}
