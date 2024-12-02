using System;

// Component Interface: Defines the base behavior for pizzas
public interface IPizza
{
    string GetDescription(); // Get the pizza description
    double GetCost();        // Get the pizza cost
}

// ConcreteComponent: The plain pizza implementation
public class PlainPizza : IPizza
{
    public string GetDescription()
    {
        return "Plain Pizza"; // Base description
    }

    public double GetCost()
    {
        return 5.00; // Base cost of the plain pizza
    }
}

// Abstract Decorator: Base class for all pizza decorators
public abstract class PizzaDecorator : IPizza
{
    protected IPizza _pizza; // Reference to the pizza being decorated

    public PizzaDecorator(IPizza pizza)
    {
        _pizza = pizza; // Initialize with the pizza to decorate
    }

    public abstract string GetDescription(); // Abstract method for description
    public abstract double GetCost();        // Abstract method for cost
}

// Concrete Decorator: Adds Cheese to the pizza
public class Cheese : PizzaDecorator
{
    public Cheese(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", Cheese"; // Add cheese to the description
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 1.50; // Add cheese cost
    }
}

// Concrete Decorator: Adds Pepperoni to the pizza
public class Pepperoni : PizzaDecorator
{
    public Pepperoni(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", Pepperoni"; // Add pepperoni to the description
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 2.00; // Add pepperoni cost
    }
}

// Client Code: Demonstrates usage of the Decorator Pattern
class Program
{
    static void Main(string[] args)
    {
        // Start with a plain pizza
        IPizza pizza = new PlainPizza();

        // Decorate the pizza with cheese
        pizza = new Cheese(pizza);

        // Decorate the pizza with pepperoni
        pizza = new Pepperoni(pizza);

        // Display the final pizza description and cost
        Console.WriteLine("Description: " + pizza.GetDescription()); // Outputs: Plain Pizza, Cheese, Pepperoni
        Console.WriteLine("Total Cost: $" + pizza.GetCost());        // Outputs: $8.50

        Console.ReadLine();
    }
}
