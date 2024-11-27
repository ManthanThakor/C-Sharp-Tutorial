using System;

namespace DependencyInversionPrincipleExample
{
    // Step 1: Create an abstraction (interface) for logging
    public interface ILogger
    {
        void Log(string message);
    }

    // Step 2: Create a concrete implementation of ILogger
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[ConsoleLogger] {message}");
        }
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            // Simulate file logging
            Console.WriteLine($"[FileLogger] {message}");
        }
    }

    // Step 3: Use the abstraction in the high-level module
    public class UserService
    {
        private readonly ILogger _logger;

        // Dependency Injection via constructor
        public UserService(ILogger logger)
        {
            _logger = logger;
        }

        public void CreateUser(string username)
        {
            // Business logic for creating a user
            Console.WriteLine($"User '{username}' has been created.");

            // Log the operation using the injected logger
            _logger.Log($"User '{username}' created successfully.");
        }
    }

    // Step 4: Create the main program to demonstrate usage
    class Program
    {
        static void Main(string[] args)
        {
            // Option 1: Use ConsoleLogger
            ILogger consoleLogger = new ConsoleLogger();
            UserService userServiceWithConsoleLogger = new UserService(consoleLogger);
            userServiceWithConsoleLogger.CreateUser("Manthan");

            Console.WriteLine();

            // Option 2: Use FileLogger
            ILogger fileLogger = new FileLogger();
            UserService userServiceWithFileLogger = new UserService(fileLogger);
            userServiceWithFileLogger.CreateUser("xyz");

            Console.ReadLine();
        }
    }
}
