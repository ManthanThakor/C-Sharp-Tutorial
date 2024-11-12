using System;

namespace MergedExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example 1: Variables and Data Types
            // Integer variables
            int age = 30;
            long population = 8000000000L; // 'L' indicates a long literal

            // Floating-point variables
            float pi = 3.14159F; // 'F' indicates a float literal
            double distanceToMoon = 384400.0; // double precision
            decimal price = 199.99M; // 'M' indicates a decimal literal

            // Character and Boolean
            char initial = 'C';
            bool isCSharpFun = true;

            // String variable
            string welcomeMessage = "Welcome to C#";

            // Implicitly typed variable (var)
            var inferredVariable = "I am a string";

            // Array declaration
            int[] numbers = { 10, 20, 30, 40, 50 };
            string[] fruits = new string[] { "Apple", "Banana", "Cherry" };

            // Constant
            const double EarthGravity = 9.81;

            // Outputting values
            Console.WriteLine("Integer value: " + age);
            Console.WriteLine("Long value: " + population);
            Console.WriteLine("Float value (Pi): " + pi);
            Console.WriteLine("Double value (Distance to Moon): " + distanceToMoon);
            Console.WriteLine("Decimal value (Price): " + price);
            Console.WriteLine("Character value: " + initial);
            Console.WriteLine("Boolean value (Is C# fun?): " + isCSharpFun);
            Console.WriteLine("String value: " + welcomeMessage);
            Console.WriteLine("Inferred variable value: " + inferredVariable);
            Console.WriteLine("Array element [0]: " + numbers[0]);
            Console.WriteLine("First fruit: " + fruits[0]);
            Console.WriteLine("Constant value (Earth Gravity): " + EarthGravity);

            // Array iteration example
            Console.WriteLine("\nArray Elements:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            // Example 2: Type Conversion
            // Implicit Conversion Example
            int intVal = 100;
            double doubleVal = intVal; // Automatic conversion from int to double
            Console.WriteLine("\nImplicit Conversion (int to double): " + doubleVal);

            // Explicit Conversion Example
            double largeDouble = 12345.67;
            int smallInt = (int)largeDouble; // Manual conversion, fractional part lost
            Console.WriteLine("Explicit Conversion (double to int): " + smallInt);

            // String to Numeric Conversion
            string strNumber = "456";
            int parsedNumber = int.Parse(strNumber); // String to int
            Console.WriteLine("String to Integer using Parse: " + parsedNumber);

            string strDecimal = "789.45";
            double convertedDecimal = Convert.ToDouble(strDecimal); // String to double using Convert
            Console.WriteLine("String to Double using Convert: " + convertedDecimal);

            // Numeric to String Conversion
            int numb = 789;
            string numbString = numb.ToString(); // Int to String
            Console.WriteLine("Integer to String: " + numbString);

            float floatValue = 45.89f;
            string floatString = floatValue.ToString(); // Float to String
            Console.WriteLine("Float to String: " + floatString);

            // Converting Between Numeric Types
            int intNumber = 500;
            short shortNumber = (short)intNumber; // Explicit conversion
            Console.WriteLine("Int to Short (Explicit Conversion): " + shortNumber);

            float floatNum = 25.5f;
            double doubleNum = floatNum; // Implicit conversion
            Console.WriteLine("Float to Double (Implicit Conversion): " + doubleNum);

            // Use of TryParse to handle invalid conversions
            string invalidString = "123abc";
            bool success = int.TryParse(invalidString, out int result);
            if (success)
            {
                Console.WriteLine("Successfully converted string to int: " + result);
            }
            else
            {
                Console.WriteLine("Failed to convert string to int.");
            }

            // Example 3: Conversion Methods
            // String to Integer Conversion
            string strToInt = "123";
            int intNumberFromString = Convert.ToInt32(strToInt);
            Console.WriteLine("\nConverted string to integer: " + intNumberFromString);

            // Double to Integer Conversion
            double doubleValue = 45.67;
            int intFromDouble = Convert.ToInt32(doubleValue); // Converts and truncates decimal part
            Console.WriteLine("Converted double to integer: " + intFromDouble);

            // End of program, waits for user input
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
