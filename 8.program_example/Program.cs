using System;
using System.Runtime.CompilerServices;

namespace program
{
    class Practical
    {
        static void Main(string[] args)
        {

            /*
            //1. Check if a number is positive or negative

            console.writeline("check if a number is positive or negative\n");
            console.write("enter the number: ");
            int num = int.parse(console.readline());

            if (num > 0)
            {
                console.writeline("the number is positive.");
            }
            else if (num == 0)
            {
                console.writeline("the number is 0.");
            }
            else
            {
                console.writeline("the number is negative.");
            }

            //===========================
            // Output: Depends on input 
            //===========================

            // 2. Check if a Number is Even or Odd
            //Console.WriteLine("Check if a Number is Even or Odd\n");

            int num2 = 10;

            if (num2 % 2 == 0)
            {
                Console.WriteLine("The number is even.");
            }
            else
            {
                Console.WriteLine("The number is Odd.");
            }

            //===========================
            // Output: The number is even.
            //===========================

                    
            // 3. Check the Largest of Two Numbers
            Console.WriteLine("Check the Largest of Two Numbers\n");

            int a = 1;
            int b = 2;

            if (a > b)
            {
                Console.WriteLine("a is greater.");
            }
            else
            {
                Console.WriteLine("b is greater.");
            }

            //===========================
            // Output: b is greater.
            //===========================

            // 4. Check if a Year is a Leap Yeark
            Console.WriteLine("Check if a Year is a Leap Yeark\n");

            int year = 2024;

            if((year % 4  == 0 && year % 100 !=0) || (year % 400 == 0 ))
            {
                Console.WriteLine($"The year {year}  is a leap year.");
            }
            else
            {
                Console.WriteLine($"The year {year} is not a leap year.");
            }

            //===========================
            // Output: The year 2024  is a leap year..
            //===========================
         
            // 5. Check if a Character is a Vowel or Consonant
            Console.WriteLine("Check if a Character is a Vowel or Consonant\n");

            char ch = 'a';

            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u' ||
                ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U')
            {
                Console.WriteLine($"The character {ch} is a vowel.");
            }
            else
            {
                Console.WriteLine($"The character {ch} is a consonant.");
            }

            //===========================
            // Output: The character a is a vowel.
            //===========================
             
            // 6. Grade Classification
            Console.WriteLine("Grade Classification\n");

            int marks = 85;
            if (marks >= 90)
            {
                Console.WriteLine("Grade: A+");
            }
            else if (marks >= 80)
            {
                Console.WriteLine("Grade: A");
            }
            else if (marks >= 70)
            {
                Console.WriteLine("Grade: B");
            }
            else
            {
                Console.WriteLine("Grade: C");
            }

            //===========================
            // Output: Grade: A   
            //===========================
             
            // 7. Check Eligibility to Vote
            Console.WriteLine("Check Eligibility to Vote\n");

            int age = 20;
            if (age >= 18)
            {
                Console.WriteLine("Eligible to vote.");
            }
            else
            {
                Console.WriteLine("Not eligible to vote.");
            }

            //===========================
            // Output: Eligible to vote.
            //===========================
        
            // 8. Simple Login System
            Console.WriteLine("Simple Login System\n");

            string username = "user";
            string password = "pass";
            if (username == "admin" && password == "admin")
            {
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }

            //===========================
            // Output: Invalid username or password.
            //===========================
             
            // 9. Number Comparison with Zero
            Console.WriteLine("Number Comparison with Zero\n");

            int num = 0;
            if (num > 0)
            {
                Console.WriteLine("Number is positive.");
            }
            else if (num < 0)
            {
                Console.WriteLine("Number is negative.");
            }
            else
            {
                Console.WriteLine("Number is zero.");
            }
            //===========================
            // Output: Number is zero.
            //===========================
    
            // 10. Check if a Number is Divisible by 5 and 3
            Console.WriteLine("Check if a Number is Divisible by 5 and 3\n");

            int num = 15;
            if (num % 3 == 0 && num % 5 == 0)
            {
                Console.WriteLine("Number is divisible by both 3 and 5.");
            }
            else
            {
                Console.WriteLine("Number is not divisible by both 3 and 5.");
            }

            //===========================
            // Output: Number is divisible by both 3 and 5.
            //===========================
                       */
            // 11. Determine Largest of Three Numbers
            Console.WriteLine("Determine Largest of Three Numbers\n");

            int x = 12, y = 45, z = 25;
            if (x > y && x > z)
            {
                Console.WriteLine("x is the largest.");
            }
            else if (y > z)
            {
                Console.WriteLine("y is the largest.");
            }
            else
            {
                Console.WriteLine("z is the largest.");
            }
            //===========================
            // Output: y is the largest.
            //===========================

            // 11. Determine Day Type
            Console.WriteLine("Determine Day Type\n");

            string day = "Saturday";
            if (day == "Saturday" || day == "Sunday")
            {
                Console.WriteLine("It's a weekend.");
            }
            else
            {
                Console.WriteLine("It's a weekday.");
            }





            Console.ReadLine();
        }

     
    }
}
