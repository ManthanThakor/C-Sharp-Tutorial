using System;

namespace Delegates
{
    // Delegate Declaration 
    public delegate void Calculation(int val1, int val2);

    class Program
    {
        //Mehtod to perform Addition 
        public void Addition(int val1, int val2)
        {
            int result = val1 + val2;
            Console.WriteLine("Addition result is : {0}", result);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\n Delegates \n");


            // Instantiate the Program class
            Program program = new Program();

            //  using the delegate
            Calculation Calc = new Calculation(program.Addition); // Assign the method to the delegate
            Calc(11, 21); // call the method via delegate

            Console.ReadLine();
        }
    }
}

