using System;

// Subject interface which both RealSubject and Proxy will implement
public interface ISubject
{
    void Request();
}

// RealSubject class: The actual object that performs the real work
public class RealSubject : ISubject
{
    public void Request()
    {
        // The real work happens here
        Console.WriteLine("Request made to RealSubject.");
    }
}

// Proxy class: Controls access to the RealSubject and can add extra functionality
public class Proxy : ISubject
{
    // A reference to the RealSubject object
    private RealSubject _realSubject;

    public void Request()
    {
        // Proxy can perform additional tasks, such as lazy initialization or logging
        if (_realSubject == null)
        {
            // Lazily instantiate the RealSubject
            _realSubject = new RealSubject();
        }

        // Proxy adds its own behavior, then delegates the request to RealSubject
        Console.WriteLine("Proxy: Delegating the request to RealSubject.");
        _realSubject.Request();
    }
}

// Client class: Uses the Proxy to interact with the RealSubject
public class Client
{
    public static void Main(string[] args)
    {
        // Create a Proxy object (client does not need to know about the RealSubject)
        ISubject subject = new Proxy();

        // Client calls the Proxy, which handles delegating the request to RealSubject
        subject.Request();  // Will delegate to RealSubject

        Console.ReadLine();
    }
}
