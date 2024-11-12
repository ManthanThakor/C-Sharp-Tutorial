using System;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 50;
            int c = 30;

            if (a > b && a > c)
            {
                Console.WriteLine("A is greater than B and C");
            }
            else if (b > c && b > a)
            {
                Console.WriteLine("B is greater than C and A");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("C is the largest");
                Console.WriteLine(" ");

            }
            Console.WriteLine("Now Switch statment example:");

            int dayOfWeek = 3;

            switch(dayOfWeek)
            {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Friday");
                break;
            case 6:
                Console.WriteLine("Saturday");
                break;
            case 7:
                Console.WriteLine("Sunday");
                break;
            default:
                Console.WriteLine("Invalid day of the week");
                break;

            }

            Console.Write("TernaryOperatorExample");


            int numb;
            Console.Write("Enter the Number:");
            numb = Convert.ToInt32(Console.ReadLine());

            string result = (numb % 2 == 0) ? "It is Even Number" : "It is Odd Number";

            Console.WriteLine($"The number is {result}.");
            Console.ReadLine();


            // Prevents the console from closing immediately
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
