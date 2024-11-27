using System;

namespace InterfaceSegregationPrinciple
{
    public interface IDrive
    {
        void Drive();
    }
    public interface IFly
    {
        void Fly();
    }
    public interface ISail
    { 
        void Sail();
    }

    public class Car : IDrive
    {
        public void Drive()
        {
            Console.WriteLine("Driving the Car...");
        }
    }

    public class Airplan : IDrive , IFly
    { 
        public void Drive()
        {
            Console.WriteLine("Driving the Airplane on the runway...");
        }
        public void Fly()
        {
            Console.WriteLine("Flying the Airplane...");
        }
    }

    public class Boat : IDrive, ISail
    {
        public void Drive()
        {
            Console.WriteLine("Driving the boat on land ....")
        }
        public void Sail()
        {
            Console.WriteLine("Sailing the Boat on water...");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n InterFace Segregation Principle \n");


            Console.ReadLine();
        }
    }
}
