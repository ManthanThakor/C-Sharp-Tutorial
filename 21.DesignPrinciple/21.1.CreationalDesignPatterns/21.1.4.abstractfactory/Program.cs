using System;

public abstract class Button
{
    public abstract void Render();
}

public abstract class Checkbox
{
    public abstract void Render();
}

public class WindowsButton : Button
{
    public override void Render()
    {
        Console.WriteLine("Rendering Windows Button");
    }
}

public class WindowsCheckbox : Checkbox
{
    public override void Render()
    {
        Console.WriteLine("Rendering Windows Checkbox");
    }
}

public class MacButton : Button
{
    public override void Render()
    {
        Console.WriteLine("Rendering Mac Button");
    }
}

public class MacCheckbox : Checkbox
{
    public override void Render()
    {
        Console.WriteLine("Rendering Mac Checkbox");
    }
}

public interface IUIFactory
{
    Button CreateButton();
    Checkbox CreateCheckbox();
}

public class WindowsFactory : IUIFactory
{
    public Button CreateButton() => new WindowsButton();
    public Checkbox CreateCheckbox() => new WindowsCheckbox();
}

public class MacFactory : IUIFactory
{
    public Button CreateButton() => new MacButton();
    public Checkbox CreateCheckbox() => new MacCheckbox();
}

public class Program
{
    public static void Main()
    {
        IUIFactory factory = new WindowsFactory(); 

        Button button = factory.CreateButton();
        Checkbox checkbox = factory.CreateCheckbox();

        button.Render();
        checkbox.Render();

        IUIFactory factory2 = new MacFactory();
        Button button2 = factory2.CreateButton();
        Checkbox checkbox2 = factory2.CreateCheckbox();

        button2.Render();
        checkbox2.Render();

        Console.ReadLine();

    }
}
