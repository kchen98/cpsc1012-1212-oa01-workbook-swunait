﻿using System;

namespace LoopCall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from the Main method.");
            for (int count = 1; count <= 5; count++)
            {
                DisplayMessage();
            }
            Console.WriteLine("Back in the Main method.");
        }

        // The DisplayMessage method displays a greeting.
        static void DisplayMessage()
        {
            Console.WriteLine("Hello from the DisplayMessage method.");
        }

    }
}
