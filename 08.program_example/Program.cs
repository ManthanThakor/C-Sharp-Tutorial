using System;

namespace Program
{
    class Practical
    {
        static void Main(string[] args)
        {
            // 1. Check if a number is positive or negative
            Console.WriteLine("\nCheck if a number is positive or negative");
            Console.Write("Enter the number: ");
            int num = int.Parse(Console.ReadLine());

            if (num > 0)
            {
                Console.WriteLine("The number is positive.");
            }
            else if (num == 0)
            {
                Console.WriteLine("The number is 0.");
            }
            else
            {
                Console.WriteLine("The number is negative.");
            }

            // ===========================
            // Output: Depends on input
            // ===========================

            // 2. Check if a Number is Even or Odd
            Console.WriteLine("\nCheck if a number is positive or negative");

            int num2 = 10;
            if (num2 % 2 == 0)
            {
                Console.WriteLine("The number is even.");
            }
            else
            {
                Console.WriteLine("The number is odd.");
            }

            // ===========================
            // Output: The number is even.
            // ===========================

            // 3. Check the Largest of Two Numbers
            Console.WriteLine("\nCheck the Largest of Two Numbers");

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

            // ===========================
            // Output: b is greater.
            // ===========================

            // 4. Check if a Year is a Leap Year
            Console.WriteLine("\nCheck if a Year is a Leap Year");

            int year = 2024;

            if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
            {
                Console.WriteLine($"The year {year} is a leap year.");
            }
            else
            {
                Console.WriteLine($"The year {year} is not a leap year.");
            }

            // ===========================
            // Output: The year 2024 is a leap year.
            // ===========================

            // 5. Check if a Character is a Vowel or Consonant
            Console.WriteLine("\nCheck if a Character is a Vowel or Consonant");

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

            // ===========================
            // Output: The character a is a vowel.
            // ===========================

            // 6. Grade Classification
            Console.WriteLine("\nGrade Classification");

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

            // ===========================
            // Output: Grade: A
            // ===========================

            // 7. Check Eligibility to Vote
            Console.WriteLine("\nCheck Eligibility to Vote");

            int age = 20;
            if (age >= 18)
            {
                Console.WriteLine("Eligible to vote.");
            }
            else
            {
                Console.WriteLine("Not eligible to vote.");
            }

            // ===========================
            // Output: Eligible to vote.
            // ===========================

            // 8. Simple Login System
            Console.WriteLine("\nSimple Login System");

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

            // ===========================
            // Output: Invalid username or password.
            // ===========================

            // 9. Number Comparison with Zero
            Console.WriteLine("\nNumber Comparison with Zero");

            int num3 = 0;
            if (num3 > 0)
            {
                Console.WriteLine("Number is positive.");
            }
            else if (num3 < 0)
            {
                Console.WriteLine("Number is negative.");
            }
            else
            {
                Console.WriteLine("Number is zero.");
            }

            // ===========================
            // Output: Number is zero.
            // ===========================

            // 10. Check if a Number is Divisible by 5 and 3
            Console.WriteLine("\nCheck if a Number is Divisible by 5 and 3");

            int num4 = 15;
            if (num4 % 3 == 0 && num4 % 5 == 0)
            {
                Console.WriteLine("Number is divisible by both 3 and 5.");
            }
            else
            {
                Console.WriteLine("Number is not divisible by both 3 and 5.");
            }

            // ===========================
            // Output: Number is divisible by both 3 and 5.
            // ===========================

            // 11. Determine Largest of Three Numbers
            Console.WriteLine("\nDetermine Largest of Three Numbers");

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

            // ===========================
            // Output: y is the largest.
            // ===========================

            // 12. Determine Day Type
            Console.WriteLine("\nDetermine Day Type");

            string day = "Saturday";
            if (day == "Saturday" || day == "Sunday")
            {
                Console.WriteLine("It's a weekend.");
            }
            else
            {
                Console.WriteLine("It's a weekday.");
            }

            // ===========================
            // Output: It's a weekend.
            // ===========================

            // 13. Check if a Number Lies in a Range
            Console.WriteLine("\nCheck if a Number Lies in a Range");

            int number = 25;
            if (number >= 10 && number <= 50)
            {
                Console.WriteLine("Number lies within the range 10-50.");
            }
            else
            {
                Console.WriteLine("Number does not lie within the range 10-50.");
            }

            // ===========================
            // Output: Number lies within the range 10-50.
            // ===========================

            // 14. Simple Traffic Light System
            Console.WriteLine("\nSimple Traffic Light System");

            string lightColor = "Red";
            if (lightColor == "Green")
            {
                Console.WriteLine("Go.");
            }
            else if (lightColor == "Yellow")
            {
                Console.WriteLine("Ready to stop.");
            }
            else
            {
                Console.WriteLine("Stop.");
            }
            // ===========================
            // Output: Number lies within the range 10-50.
            // ===========================

            // 15.Temperature Check
            Console.WriteLine("\nTemperature Check");

            int temperatureFahrenheit = 86; // Fahrenheit temperature
            int temperatureCelsius = (temperatureFahrenheit - 32) * 5 / 9;

            if (temperatureCelsius > 35)
            {
                Console.WriteLine("It's a hot day.");
            }
            else if (temperatureCelsius > 20)
            {
                Console.WriteLine("It's a pleasant day.");
            }
            else
            {
                Console.WriteLine("It's a cold day.");
            }
            // ===========================
            // Output: It's a pleasant day.   
            // ===========================

            //==========================================
            //==========================================
            Console.WriteLine("   ");
            Console.WriteLine("\n================ Nested If else examples ===============");
            Console.WriteLine("    ");
            //==========================================
            //==========================================

            // 1. Determine Discount Based on Age and Membership Status
            Console.WriteLine("\nDetermine Discount Based on Age and Membership Status");

            int agee = 65;
            bool isMember = true;
            if (agee >= 60)
            {
                if (isMember)
                {
                    Console.WriteLine("You get a 30% discount.");
                }
                else
                {
                    Console.WriteLine("You get a 10% discount.");

                }
            }
            else
            {
                if (isMember)
                {
                    Console.WriteLine("You get a 10% discount.");
                }
                else
                {
                    Console.WriteLine("You are not eligible for a discount.");

                }
            }
            // ===========================
            // Output: You get a 30 % discount.   
            // ===========================

            // 2. Determine Traffic Light Action
            Console.WriteLine("\nDetermine Traffic Light Action");

            string lightColor2 = "Yellow";
            if (lightColor2 == "Green")
            {
                Console.WriteLine("Go.");
            }
            else if (lightColor2 == "Yellow")
            {
                Console.WriteLine("Prepare to stop.");
            }
            else
            {
                if (lightColor2 == "Red")
                {
                    Console.WriteLine("Stop.");
                }
                else
                {
                    Console.WriteLine("Invalid light color.");
                }
            }
            // ===========================
            // Output:  Prepare to stop.
            // ===========================

            // 2. Day Type and Activity Based on Day
            Console.WriteLine("\nDay Type and Activity Based on Day");

            string day2 = "Monday";
            if (day2 == "Saturday" || day2 == "Sunday")
            {
                if (day2 == "Saturday")
                {
                    Console.WriteLine("It's a weekend, time to relax.");
                }
                else
                {
                    Console.WriteLine("It's a weekend, time to enjoy!");
                }
            }
            else if (day2 == "Monday" || day2 == "Friday")
            {
                Console.WriteLine("It's a workday, get ready for the week.");
            }
            else
            {
                Console.WriteLine("It's a regular workday.");
            }
            // ===========================
            // Output:  It's a workday, get ready for the week. 
            // ===========================

            Console.ReadLine();
        }
    }
}
