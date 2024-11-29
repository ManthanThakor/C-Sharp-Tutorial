public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Circle");
    }
}

public class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Rectangle");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a Square");
    }
}

public class ShapeFactory
{
    public IShape GetShape(string shapeType)
    {
        if (shapeType == null) return null;

        if (shapeType.Equals("CIRCLE", StringComparison.OrdinalIgnoreCase))
        {
            return new Circle();
        }
        else if (shapeType.Equals("RECTANGLE", StringComparison.OrdinalIgnoreCase))
        {
            return new Rectangle();
        }
        else if (shapeType.Equals("SQUARE", StringComparison.OrdinalIgnoreCase))
        {
            return new Square();
        }

        return null;
    }
}

public class Program
{
    public static void Main()
    {
        ShapeFactory factory = new ShapeFactory();

        IShape shape1 = factory.GetShape("CIRCLE");
        shape1?.Draw(); 

        IShape shape2 = factory.GetShape("RECTANGLE");
        shape2?.Draw(); 

        IShape shape3 = factory.GetShape("SQUARE");
        shape3?.Draw(); 
    }
}
