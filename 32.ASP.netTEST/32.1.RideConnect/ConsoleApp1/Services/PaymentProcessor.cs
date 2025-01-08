using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(Passenger passenger, decimal amount);
    }

    public class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(Passenger passenger, decimal amount)
        {
            Console.WriteLine($"Processing credit card payment for {passenger.Name}: ${amount}");
        }
    }

    public class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(Passenger passenger, decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment for {passenger.Name}: ${amount}");
        }
    }

    public class WalletProcessor : IPaymentProcessor
    {
        public void ProcessPayment(Passenger passenger, decimal amount)
        {
            Console.WriteLine($"Processing wallet payment for {passenger.Name}: ${amount}");
        }
    }
}
