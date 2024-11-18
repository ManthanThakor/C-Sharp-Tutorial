using System;

namespace JaggedArray
{
    class Program
    {
        static void Main(string[] args) 
        {
            Console.WriteLine("\nJaggedArray:\n");

            // ====================================================================== //
            Console.WriteLine("\n jagged array with 2 single-dimensional arrays\n");
            // ====================================================================== //

            //  Array is a jagged array that holds 1D arrays.
            //  Array[0] is a 1D array with 3 elements: { 1, 2, 3}.
            //  Array[1] is a 1D array with 2 elements: { 1, 2}.

            int[][] Array = new int[2][]{
                                    new int[3]{1,2,3 },
                                    new int[2]{1,2}
                                    };

            for(int i = 0; i < Array.Length; i++)
            {
                for(int j = 0; j < Array[i].Length; j++)
                {
                    Console.Write(Array[i][j]);
                }
                Console.WriteLine("\n");
            }

            // ====================================================================== //
            Console.WriteLine("\n Jagged array for storing student scores \n");
            // ====================================================================== //

            int[][] studentScores = new int[4][]; 

            studentScores[0] = new int[] { 85, 90, 78 }; 
            studentScores[1] = new int[] { 92, 88 };     
            studentScores[2] = new int[] { 70, 75, 80, 85 };  
            studentScores[3] = new int[] { 95 };        

            for (int i = 0; i < studentScores.Length; i++)
            {
                Console.Write("Student " + (i + 1) + " scores: ");
                for (int j = 0; j < studentScores[i].Length; j++)
                {
                    Console.Write(studentScores[i][j] + " ");
                }
                Console.WriteLine();
            }
            // ====================================================================== //
            Console.WriteLine("\n jagged array with 3 two-dimensional arrays\n");
            // ====================================================================== //

            int[][][] jaggedArray3d = new int[3][][]
            {
                new int [2][]
                {
                    new int[3] { 1, 2, 3 },
                    new int[2] { 4, 5 }     
                },
                new int [1][]
                {
                    new int[3] { 1, 2 , 3 }
                },
                 new int [3][]
                {
                    new int[3] { 1, 2 , 3 },
                    new int[3] { 1, 2 , 3 }
                    new int[3] { 1, 2 , 3 }

                },
            }
            Console.ReadLine();
        }
    }
}