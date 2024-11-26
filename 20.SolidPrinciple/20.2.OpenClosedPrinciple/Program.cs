using System;

namespace OpenClosePrinciple
{
    public interface Ipayment
    { 
        void ProcessPayment();
    }

    public  class CreditCardPayment : Ipayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing Credit Card payment...");
        }
    }
    public class PayPalPayment : Ipayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing PayPal payment...");
        }
    }
    public class PaymentProcessor
    {
        public void ProcessPayment(Ipayment payment)
        {
            payment.ProcessPayment();
        }
    }
    public class ApplePayPayment : Ipayment
    {
        public void ProcessPayment()
        {
            Console.WriteLine("Processing Apple Pay payment...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n Solid Principle : OpenClose Principle \n");

            PaymentProcessor paymentProcessor = new PaymentProcessor();

            Ipayment creditCardPayment = new CreditCardPayment();
            Ipayment payPalPayment = new PayPalPayment();
            Ipayment applePayPayment = new ApplePayPayment();

            paymentProcessor.ProcessPayment(creditCardPayment);
            paymentProcessor.ProcessPayment(payPalPayment);
            paymentProcessor.ProcessPayment(applePayPayment);



            Console.ReadLine();
        }
    }
}