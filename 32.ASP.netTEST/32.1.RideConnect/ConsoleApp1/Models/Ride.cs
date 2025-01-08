using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Ride
    {
        public int RideId { get; set; }
        public Passenger Passenger { get; set; }
        public Driver Driver { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public string Status { get; set; }

        public Ride(int rideId, Passenger passenger, string pickupLocation, string dropLocation)
        {
            RideId = rideId;
            Passenger = passenger;
            PickupLocation = pickupLocation;
            DropLocation = dropLocation;
            Status = "Requested";
        }
    }

}
