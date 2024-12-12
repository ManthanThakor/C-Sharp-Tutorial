using System;
using System.Collections.Generic;

// Observer interface
public interface IObserver
{
    void Update(string message);
}

// Subject interface
public interface ISubject
{
    void Attach(IObserver observer);  // Add observer
    void Detach(IObserver observer);  // Remove observer
    void Notify();                   // Notify all observers
}

// ConcreteSubject
public class WeatherStation : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    private string _weatherUpdate;

    public void SetWeatherUpdate(string update)
    {
        _weatherUpdate = update;
        Notify();
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_weatherUpdate);
        }
    }
}

// ConcreteObserver
public class WeatherApp : IObserver
{
    private string _appName;

    public WeatherApp(string appName)
    {
        _appName = appName;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{_appName} received weather update: {message}");
    }
}

// Client code
public class Program
{
    public static void Main(string[] args)
    {
        // Create Subject
        var weatherStation = new WeatherStation();

        // Create Observerssd
        var weatherApp1 = new WeatherApp("WeatherApp1");
        var weatherApp2 = new WeatherApp("WeatherApp2");

        // Attach Observers to Subject
        weatherStation.Attach(weatherApp1);
        weatherStation.Attach(weatherApp2);

        // Change state in Subject
        weatherStation.SetWeatherUpdate("Sunny, 25°C");

        // Detach an Observer
        weatherStation.Detach(weatherApp1);

        // Change state again
        weatherStation.SetWeatherUpdate("Rainy, 18°C");
        Console.ReadLine();
    }
}
