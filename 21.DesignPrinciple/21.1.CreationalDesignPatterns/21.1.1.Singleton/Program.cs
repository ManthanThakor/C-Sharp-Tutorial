using System;

namespace Singleton
{
    // The Singleton class is sealed to prevent inheritance.
    public sealed class Singleton
    {
        // The Lazy<T> type ensures that the Singleton instance is created only when it is needed (lazy initialization).
        // This initialization is thread-safe by default.
        private static readonly Lazy<Singleton> lazyInstance = new Lazy<Singleton>(() => new Singleton());

        // Private constructor ensures that no instances of Singleton can be created directly from outside the class.
        private Singleton() { }

        // Public property to access the Singleton instance.
        public static Singleton Instance
        {
            get { return lazyInstance.Value; }
        }

        // Method to display a message.
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Property to check if the Singleton instance has been created.
        public static bool IsInstanceCreated => lazyInstance.IsValueCreated;
    }

    class Program
    {
        static void Main()
        {
            // Before accessing the Singleton instance, check if it has been created.
            Console.WriteLine("Has the Singleton instance been created? " + Singleton.IsInstanceCreated);

            // Accessing the Singleton instance for the first time.
            Singleton singleton = Singleton.Instance;
            singleton.DisplayMessage("Hello from singleton!");

            // Checking again after accessing the instance.
            Console.WriteLine("Has the Singleton instance been created? " + Singleton.IsInstanceCreated);

            // Accessing the Singleton instance again (this will refer to the same instance).
            Singleton singleton2 = Singleton.Instance;
            singleton2.DisplayMessage("Singleton pattern in action!");

            Console.ReadLine();
        }
    }
}
