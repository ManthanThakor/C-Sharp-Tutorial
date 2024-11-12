using System;

namespace program {

class prog
    {
        static void Main(string[] args)
        {
            string color, pluralNoun, celebrity;

            Console.Write("Enter A color: ");
            color = Console.ReadLine();

            Console.Write("Enter A pluralNoun: ");
            pluralNoun = Console.ReadLine();

            Console.Write("Enter A celebrity: ");
            celebrity = Console.ReadLine();

            Console.WriteLine($"Roses are {color}");
            Console.WriteLine($"{pluralNoun} are blue");
            Console.WriteLine($"I love {celebrity}");
            /*      Enter A color: df
                    Enter A pluralNoun: af
                    Enter A celebrity: fsa
                    Roses are df    
                    af are blue
                    I love fsa*/
           


        }  
    }
}