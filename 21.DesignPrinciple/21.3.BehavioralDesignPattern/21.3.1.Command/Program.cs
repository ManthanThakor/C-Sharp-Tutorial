using System;

// Command Interface
public interface ICommand
{
    void Execute();
}

// Receiver (Light)
public class Light
{
    public void TurnOn() => Console.WriteLine("Light is On");
    public void TurnOff() => Console.WriteLine("Light is Off");
}

// Concrete Command to Turn On the Light
public class LightOnCommand : ICommand
{
    private Light _light;
    public LightOnCommand(Light light) => _light = light;
    public void Execute() => _light.TurnOn();
}

// Concrete Command to Turn Off the Light
public class LightOffCommand : ICommand
{
    private Light _light;
    public LightOffCommand(Light light) => _light = light;
    public void Execute() => _light.TurnOff();
}

// Invoker (RemoteControl)
public class RemoteControl
{
    private ICommand _command;
    public void SetCommand(ICommand command) => _command = command;
    public void PressButton() => _command.Execute(); // Executes the command
}

// Client (Program)
public class Program
{
    public static void Main()
    {
        Light light = new Light(); // Receiver
        ICommand lightOn = new LightOnCommand(light);  // Concrete Command
        ICommand lightOff = new LightOffCommand(light); // Concrete Command
        RemoteControl remote = new RemoteControl(); // Invoker

        remote.SetCommand(lightOn);  // Set command to turn on light
        remote.PressButton();        // Executes light on

        remote.SetCommand(lightOff); // Set command to turn off light
        remote.PressButton();        // Executes light off
    }
}
