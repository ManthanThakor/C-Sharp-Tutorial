﻿using System;
using System.Collections;

class Program
{
    static void Main()
    {
        Hashtable table = new Hashtable();
        table.Add(1, "Apple");
        table.Add(2, "Banana");
        table.Add(3, "Cherry");

        Console.WriteLine(table[1]);   
        Console.WriteLine(table[2]);  
        Console.ReadLine();
    }
}