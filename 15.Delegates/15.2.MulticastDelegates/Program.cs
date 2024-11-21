using System;

namespace MultiCast
{
    public delegate void DisplayDelegates(string message);

    class Program
    {
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"Message: {message}");
        }

        public void DisplayLength(string message)
        {
            Console.WriteLine($"Length: {message.Length}");
        }

        static void Main(string[] args) 
        {
            Console.WriteLine("MultiCast Delegates\n");

            Program program = new Program();

            DisplayDelegates del = program.DisplayMessage;
            del += program.DisplayLength;
            del("Multicast Delegate Example");



            Console.ReadLine();
        }
    }
}