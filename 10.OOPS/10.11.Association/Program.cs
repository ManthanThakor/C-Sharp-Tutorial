using System;

namespace AssosiationSpace
{
    public class Person
    {
        public int id;
        public string name { get; set; }

        // constructor

        public Person(int eid,string ename)
        {
            id = eid;
            name = ename;
        }

        // Method to display person's name
        public void Drive(Car car)
        {
            Console.WriteLine($"{name} id driving a {car.Model}.");
        }

    }

    public class Car
    {
        public string Model { get; set; }

        public Car(string model)
        {
            Model = model;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a person and a car
            Person person = new Person(1,"John");
            Car car = new Car("Toyota");

            // Association: Person drives a car
            person.Drive(car);

            Console.ReadLine();
        }
    }
}
