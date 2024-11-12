using System;

class Program
{
    static void Main()
    {
        Pattern1(5);
        Pattern2(10);
        Pattern3(4);
        Pattern4(5);
        Pattern5(5);
        Pattern6(5);
        Pattern7(3);
        Pattern998(4);
        Pattern999(4);
        Pattern13(5);
        Pattern14(5);
        Pattern15(5);
        Pattern16(5);
        Square(4, 5);
        Pattern8(5);
        Pattern9(5);
        Pattern10(5);
        Pattern11(5);
        Pattern12(5);
        Pattern20(6);
        Pattern21(5);
        Pattern23(5);
        Console.ReadLine();

    }

    static void Pattern1(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }
    }

    static void Pattern2(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }
    }

    static void Pattern3(int num)
    {
        int number = 1;
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(number++);
            }
            Console.WriteLine();
        }
    }

    static void Pattern4(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }

    static void Pattern5(int num)
    {
        for (int i = num; i > 0; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }
    }

    static void Pattern6(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= num - i; j++)
            {
                Console.Write(" ");
            }
            for (int k = 1; k <= 2 * i - 1; k++)
            {
                Console.Write(k);
            }
            Console.WriteLine();
        }
    }

    static void Pattern7(int num)
    {
        int num1 = 1;
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= num - i; j++)
            {
                Console.Write(" ");
            }
            for (int k = 1; k <= 2 * i - 1; k++)
            {
                Console.Write(num1++);
            }
            Console.WriteLine();
        }
    }

    static void Pattern998(int num)
    {
        int oddNum = 1, evenNum = 2;
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(evenNum);
                    evenNum += 2;
                }
                else
                {
                    Console.Write(oddNum);
                    oddNum += 2;
                }
            }
            Console.WriteLine();
        }
    }

    static void Pattern999(int num)
    {
        int oddNum = 1, evenNum = 2;
        for (int i = 1; i <= num; i++)
        {
            for (int k = 1; k <= num - i; k++)
            {
                Console.Write(" ");
            }
            for (int j = 1; j <= i; j++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(evenNum);
                    evenNum += 2;
                }
                else
                {
                    Console.Write(oddNum);
                    oddNum += 2;
                }
            }
            Console.WriteLine();
        }
    }

    static void Pattern13(int num)
    {
        for (int i = num; i > 0; i--)
        {
            for (int j = num; j > num - i; j--)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }
    }

    static void Pattern14(int num)
    {
        for (int i = num; i > 0; i--)
        {
            string row = new string(' ', num - i);
            for (int j = i; j > 0; j--)
            {
                row += j;
            }
            Console.WriteLine(row);
        }
    }

    static void Pattern15(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            for (int j = num; j > num - i; j--)
            {
                Console.Write(j);
            }
            Console.WriteLine();
        }
    }

    static void Pattern16(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            string row = new string(' ', num - i);
            for (int k = 1; k <= i; k++)
            {
                row += k;
            }
            Console.WriteLine(row);
        }
    }

    static void Square(int num1, int num2)
    {
        for (int i = 1; i <= num1; i++)
        {
            for (int j = 1; j <= num2; j++)
            {
                if (i == 1 || i == num1 || j == 1 || j == num2)
                {
                    Console.Write("1");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }

    static void Pattern8(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= num; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    static void Pattern9(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= num; j++)
            {
                if (i == 1 || i == num || j == 1 || j == num)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }

    static void Pattern10(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            string row = new string(' ', num - i);
            for (int k = 1; k <= i; k++)
            {
                row += "*";
            }
            Console.WriteLine(row);
        }
    }

    static void Pattern11(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    static void Pattern12(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            string row = new string(' ', num - i);
            for (int k = 1; k <= 2 * i - 1; k++)
            {
                row += "*";
            }
            Console.WriteLine(row);
        }
    }

    static void Pattern20(int num)
    {
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
            Console.WriteLine(row);
        }
    }

    static void Pattern21(int num)
    {
        for (int i = num; i > 0; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }

    static void Pattern23(int num)
    {
        for (int i = num; i > 0; i--)
        {
            string row = new string(' ', num - i);
            for (int j = 1; j <= i; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine(row);
        }
    }
}
