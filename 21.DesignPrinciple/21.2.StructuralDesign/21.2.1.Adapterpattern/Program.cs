using System;

namespace Adapter
{
    // Step 1: Define the Target Interface (INewSystem)
    // This is the interface that the client expects to work with.
    public interface INewSystem
    {
        void NewMethod();  // Method that clients will use
    }

    // Step 2: Define the Existing (Incompatible) Class (OldSystem)
    // This class has a method that the client doesn't expect or use directly.
    public class OldSystem
    {
        // Method in the old system that the client can't directly use.
        public void OldMethod()
        {
            Console.WriteLine("Old method executed.");  // Old functionality
        }
    }

    // Step 3: Create the Adapter Class
    // The Adapter class implements the target interface (INewSystem)
    // and adapts the calls to the OldSystem's methods.
    public class Adapter : INewSystem
    {
        private OldSystem _oldSystem;  // Reference to the old system

        // Constructor: Takes an instance of OldSystem
        public Adapter(OldSystem oldSystem)
        {
            _oldSystem = oldSystem;
        }

        // Implements the NewMethod from the INewSystem interface.
        public void NewMethod()
        {
            // Adapting the call to the old method
            _oldSystem.OldMethod();  // Calls the OldMethod from the old system
        }
    }

    // Step 4: The Client Code
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the old system (OldSystem)
            OldSystem oldSystem = new OldSystem();

            // Step 5: Create an adapter to make the old system compatible with the new system interface
            INewSystem newSystem = new Adapter(oldSystem);

            // Step 6: Now, we can call NewMethod, which internally calls OldMethod
            newSystem.NewMethod();  // Calls the adapted method, which is OldMethod in the OldSystem

            // Wait for the user to press Enter before closing the application
            Console.ReadLine();
        }
    }
}
