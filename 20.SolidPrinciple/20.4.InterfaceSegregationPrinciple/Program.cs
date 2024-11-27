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
            Console.WriteLine("Driving the Car...\n");
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
            Console.WriteLine("Flying the Airplane...\n");
        }
    }

    public class Boat : IDrive, ISail
    {
        public void Drive()
        {
            Console.WriteLine("Driving the Boat on land...");
        }
        public void Sail()
        {
            Console.WriteLine("Sailing the Boat on water...\n");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n InterFace Segregation Principle \n");

            Car car = new Car();
            Console.WriteLine("Car Section");
            car.Drive();

            Airplan airplan = new Airplan();
            Console.WriteLine("Airplan Section");
            airplan.Drive();
            airplan.Fly();

            Boat boat = new Boat();
            Console.WriteLine("Boat Section");
            boat.Drive();
            boat.Sail();

            Console.ReadLine();
        }
    }
}
