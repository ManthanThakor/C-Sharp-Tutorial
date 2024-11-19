using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n List Example \n");

            List<int> student_ID = new List<int>();
            student_ID.Add(1);
            student_ID.Add(2);
            student_ID.Add(3);
            Console.WriteLine("List of names:");
           foreach(int id in student_ID)
            {
                Console.WriteLine(student_ID);

            }
            Console.ReadLine();
        }
    }

    class KeyValuePair<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }
}