using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class RideEventArgs : EventArgs
    {
        public Ride Ride { get; set; }

        public RideEventArgs(Ride ride)
        {
            Ride = ride;
        }
    }

}
