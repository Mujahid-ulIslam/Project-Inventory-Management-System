using System;
using System.Collections.Generic;
using System.Text;

// Input Helper Methods being used in Add Product Method in the Inventory Class



namespace Project_Inventory_Management_System
{
    internal static class InputHelper
    {
        public static string GetValidInput(string message)
        {
            while (true)
            {
                Console.Write(message);

                string input = Console.ReadLine();

                if (input.ToLower().Trim() == "q")
                {
                    return null;
                }

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input cannot be empty.");
                    Console.ResetColor();
                }
                else
                {
                    return input;
                }
            }
        }


        public static int? GetValidQuantity()
        {
            while (true)
            {
                Console.Write("Enter quantity: ");
                string productQuantity = Console.ReadLine();

                if (productQuantity.ToLower().Trim() == "q")
                {
                    return null;
                }

                bool isNumber = int.TryParse(productQuantity, out int parsedQuantity);



                if (!isNumber)
                {
                    ConsoleHelper.ShowError("Please enter a valid numeric quantity.");

                }

                else if (parsedQuantity < 0)
                {
                    ConsoleHelper.ShowError("Quantity cannot be negative.");
                }

                else
                {
                    return parsedQuantity;
                }


            }

        }


        public static decimal? GetValidPrice()
        {

            while (true)
            {
                Console.Write("Enter Price: ");

                string productPrice = Console.ReadLine();

                if (productPrice.ToLower().Trim() == "q")
                {
                    return null;
                }



                bool isNumber = decimal.TryParse(productPrice, out decimal parsedPrice);



                if (!isNumber)
                {

                    ConsoleHelper.ShowError("Please enter a valid numeric price.");   //  Replced the 3 lines with this one line by calling the ConsoleHelper.ShowError method and passing the message as argument
                }

                else if (parsedPrice < 0)
                {

                    ConsoleHelper.ShowError("Price cannot be negative.");

                }

                else
                {
                    return parsedPrice;
                }
            }
        }
    }
}
