using System;

class Program
{
    static void Main()
    {
        int num20 = 6;
        Console.WriteLine("Pattern 20:");
        Console.WriteLine(Pattern20(num20));

        int num21 = 5;
        Console.WriteLine("Pattern 21:");
        Console.WriteLine(Pattern21(num21));

        int num23 = 5;
        Console.WriteLine("Pattern 23:");
        Console.WriteLine(Pattern23(num23));

        Console.ReadLine();
    }

    // Pattern 20: 
    static string Pattern20(int num)
    {
        string pattern = "";
        for (int i = 1; i <= num; i++)
        {
            string row = "";
            for (int j = 1; j <= i; j++)
            {
                if (j == 1 || j == i || i == num)
                {
                    row += "*";
                }
                else
                {
                    row += " ";
                }
            }
            pattern += row + "\n";
        }
        return pattern;
    }

    // Pattern 21: 
    static string Pattern21(int num)
    {
        string pattern = "";
        for (int i = num; i > 0; i--)
        {
            string row = "";
            for (int j = 1; j <= i; j++)
            {
                row += "*";
            }
            pattern += row + "\n";
        }
        return pattern;
    }

    // Pattern 23: 
    static string Pattern23(int num)
    {
        string pattern = "";
        for (int i = num; i > 0; i--)
        {
            string row = "";
            for (int j = 1; j <= num - i; j++)
            {
                row += " ";
            }
            for (int k = 1; k <= i; k++)
            {
                row += "*";
            }
            pattern += row + "\n";
        }
        return pattern;
    }
}
