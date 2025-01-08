using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine($"Ride accepted by {Name}");
            }
            else
            {
                Console.WriteLine($"Driver {Name} is not available.");
            }
        }

        public void DeclineRide(Ride ride)
        {
            ride.Status = "Declined";
            Console.WriteLine($"Ride declined by {Name}");
        }

        public void UpdateRideStatus(Ride ride, string status)
        {
            ride.Status = status;
            Console.WriteLine($"Ride status updated to: {status}");
        }
    }

}
