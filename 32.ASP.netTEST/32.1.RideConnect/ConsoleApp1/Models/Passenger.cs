using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Services;

namespace ConsoleApp1.Models
{
    public class Passenger : User
    {
        public List<string> PaymentMethods { get; set; }

        public Passenger(int id, string name, string contactInfo, string location)
            : base(id, name, contactInfo, location)
        {
            PaymentMethods = new List<string>();
        }

        public Ride RequestRide(RideManager rideManager, string pickupLocation, string dropLocation)
        {
            return rideManager.RequestRide(this, pickupLocation, dropLocation);
        }

        public void MakePayment(IPaymentProcessor paymentProcessor, decimal amount)
        {
            paymentProcessor.ProcessPayment(this, amount);
        }
    }

}
