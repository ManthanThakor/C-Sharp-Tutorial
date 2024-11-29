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
        public static Singleton Instance
        {
            get { return lazyInstance.Value; }
        }
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        static void Main()
        {
            // Accessing the Singleton instance for the first time.
            Singleton singleton = Singleton.Instance;
            singleton.DisplayMessage("Hello from singleton!");
            // Accessing the Singleton instance again.
            // Since it's a Singleton, this will refer to the same instance created earlier.
            Singleton singleton2 = Singleton.Instance;
            singleton2.DisplayMessage("Singleton pattern in action!");

            Console.ReadLine();
        }
    }
}
