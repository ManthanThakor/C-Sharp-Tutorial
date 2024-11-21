using System;

class Program
{
    // A method that matches the Predicate<T> signature
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // A method that matches Predicate<T> with a string parameter
    static bool IsLongWord(string word)
    {
        return word.Length > 5;
    }

    static void Main()
    {
        Console.WriteLine("Example 1: Predicate with int parameter");
        // Using Predicate<int> to check if a number is even
        Predicate<int> isEvenPredicate = IsEven;

        Console.WriteLine($"Is 4 even? {isEvenPredicate(4)}"); // Output: Is 4 even? True
        Console.WriteLine($"Is 7 even? {isEvenPredicate(7)}"); // Output: Is 7 even? False

        Console.WriteLine("\nExample 2: Predicate with string parameter");
        // Using Predicate<string> to check if the word length is greater than 5
        Predicate<string> isLongWordPredicate = IsLongWord;

        Console.WriteLine($"Is 'hello' a long word? {isLongWordPredicate("hello")}"); // Output: Is 'hello' a long word? False
        Console.WriteLine($"Is 'wonderful' a long word? {isLongWordPredicate("wonderful")}"); // Output: Is 'wonderful' a long word? True

        Console.WriteLine("\nExample 3: Using Predicate with an anonymous method");
        // Using Predicate<int> with an anonymous method
        Predicate<int> isPositive = delegate (int number)
        {
            return number > 0;
        };

        Console.WriteLine($"Is 5 positive? {isPositive(5)}"); // Output: Is 5 positive? True
        Console.WriteLine($"Is -3 positive? {isPositive(-3)}"); // Output: Is -3 positive? False

        Console.WriteLine("\nExample 4: Using Predicate with a lambda expression");
        // Using Predicate<int> with a lambda expression
        Predicate<int> isNegative = (number) => number < 0;

        Console.WriteLine($"Is -8 negative? {isNegative(-8)}"); // Output: Is -8 negative? True
        Console.WriteLine($"Is 10 negative? {isNegative(10)}"); // Output: Is 10 negative? False
        Console.ReadLine();
    }
}
