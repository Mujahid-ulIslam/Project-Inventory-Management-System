using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Inventory_Management_System
{
    internal static class ConsoleHelper
    {
        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }


        public static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();

        }
    }
}
