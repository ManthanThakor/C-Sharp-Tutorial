using System;

namespace FactoryMethod
{
    // Define the product interface
    public interface IShape
    {
        // Method to be implemented by all concrete shapes
        void Draw();
    }

    // Concrete product: Circle
    public class Circle : IShape
    {
        // Implement the Draw method
        public void Draw()
        {
            Console.WriteLine("Drawing a Circle.");
        }
    }

    // Concrete product: Rectangle
    public class Rectangle : IShape
    {
        // Implement the Draw method
        public void Draw()
        {
            Console.WriteLine("Drawing a Rectangle.");
        }
    }

    // Abstract factory: Defines a method to create an IShape
    public abstract class ShapeFactory
    {
        // Abstract method to be implemented by concrete factories
        public abstract IShape CreateShape();
    }

    // Concrete factory: Creates a Circle
    public class CircleFactory : ShapeFactory
    {
        // Override the abstract method to return a Circle
        public override IShape CreateShape()
        {
            return new Circle(); // Instantiate a Circle object
        }
    }

    // Concrete factory: Creates a Rectangle
    public class RectangleFactory : ShapeFactory
    {
        // Override the abstract method to return a Rectangle
        public override IShape CreateShape()
        {
            return new Rectangle(); // Instantiate a Rectangle object
        }
    }

    // Main program to demonstrate the Factory Method pattern
    class Program
    {
        static void Main(string[] args)
        {
            // Create a factory for creating Circles
            ShapeFactory factory = new CircleFactory();
            // Use the factory to create a Circle
            IShape shape = factory.CreateShape();
            // Call the Draw method on the Circle
            shape.Draw();

            // Create a factory for creating Rectangles
            factory = new RectangleFactory();
            // Use the factory to create a Rectangle
            shape = factory.CreateShape();
            // Call the Draw method on the Rectangle
            shape.Draw();

            // Keep the console window open to see the output
            Console.ReadLine();
        }
    }
}
