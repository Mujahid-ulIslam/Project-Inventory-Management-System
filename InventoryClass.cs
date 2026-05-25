using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Project_Inventory_Management_System
{
    internal class InventoryClass
    {
        public InventoryClass(List<ProductClass> products)
        {
            Products = products;
        }

        public List<ProductClass> Products { get; set; }


        

        public bool AddProducts()
        {
            Console.WriteLine();

            string productName  = InputHelper.GetValidInput("Enter Product Name: ");

            if (productName == null) return false;  //  If InputHelper.GetValidInput method returns null the method is exited
            

            string productId = InputHelper.GetValidInput("Enter Product ID: ");

            if (productId == null) return false;
            

            int? quantity = InputHelper.GetValidQuantity();
            if (quantity == null) return false;
            
            decimal? price = InputHelper.GetValidPrice();
            if (price == null) return false;
         

            ProductClass product = new ProductClass( productName, productId, quantity, price);

            Products.Add(product);

            ConsoleHelper.ShowSuccess("Product added successfully!");

            return true;
        }


        public void UpdateProducts()
        {
            Console.WriteLine("Enter the Product ID of the product to be updated: ");
            string updateInput = Console.ReadLine();

        }


        public void ShowProducts()
        {
            Console.WriteLine("=====PRODUCTS LIST=====");
            Console.WriteLine();

            if (Products.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There are no products to display.");
                Console.ResetColor();

                return;
            }

            foreach (ProductClass product in Products.OrderBy(p => p.Price))
            {
                Console.WriteLine(product);
            }
        }













    }
    
}
