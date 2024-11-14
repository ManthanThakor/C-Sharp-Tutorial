using System;

namespace MathOperations
{
    public class Calculator
    {
        // Method with one parameter
        public int Add(int a)
        {
            return a + 10;
        }

        // Method with two parameters
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Method with different parameter types
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
}
