using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;   //Used for reading and writing files
using System.Text.Json;   // Used for converting objects to JSON and vice versa

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
            bool exists = Products.Any(p => p.Id == productId);      //  Checks if for any product p in the Products list if the product (p's) Id is same as the one given by user
            if (exists)
            {
                ConsoleHelper.ShowError("ID already exists.");
                return false;
            }



            int? quantity = InputHelper.GetValidQuantity();
            if (quantity == null) return false;
            
            decimal? price = InputHelper.GetValidPrice();
            if (price == null) return false;
         

            ProductClass product = new ProductClass( productId, productName, quantity, price);

            Products.Add(product);

            ConsoleHelper.ShowSuccess("Product added successfully!");

            return true;
        }


        public bool UpdateProducts()
        {

            string searchId = InputHelper.GetValidInput("Enter the Product ID of the product to be updated:");
            
            if (searchId == null) return false;

            ProductClass product = Products.FirstOrDefault(p => p.Id == searchId);
            if (product == null)
            {
                ConsoleHelper.ShowError("Product not found.");
                return false;
            }

            string newName = InputHelper.GetValidInput("Enter new name: ");
            if (newName == null) return false;

            int? newQuantity = InputHelper.GetValidQuantity();
            if (newQuantity == null) return false;

            decimal? newPrice = InputHelper.GetValidPrice();
            if (newPrice == null) return false;

            product.Name = newName;
            product.Quantity = newQuantity;
            product.Price = newPrice;

            ConsoleHelper.ShowSuccess("Product updated successfully!");

            return true;

            

        }


        public void ShowProducts()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("=======================================================================================");
            Console.WriteLine("                                     PRODUCTS LIST                         ");
            Console.WriteLine("=======================================================================================");

            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(
                "Name".PadRight(40) +
                "ID".PadRight(20) +
                "Quantity".PadRight(20) +
                "Price".PadRight(20)
            );

            Console.ResetColor();

            Console.WriteLine(
                "--------------------------------------------------------------------------------------");

            if (Products.Count == 0)
            {
                ConsoleHelper.ShowError("There are no products to display.");
                return;
            }

            

            foreach (ProductClass product in Products)
            {
               
                Console.WriteLine(product);
            }
        }


        public bool DeleteProducts()
        {
            string searchId = InputHelper.GetValidInput("Enter the Product ID of the product to be deleted:");

            if (searchId == null) return false;

            ProductClass product = Products.FirstOrDefault(p => p.Id == searchId);
            if (product == null)
            {
                ConsoleHelper.ShowError("Product not found.");
                return false;
            }

            Products.Remove(product);
            ConsoleHelper.ShowSuccess("Product deleted successfully!");
            return true;
        }


        public void GenerateReport()
        {
            if (Products.Count == 0)
            {
                ConsoleHelper.ShowError("No products available.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("================================================================================");
            Console.WriteLine("                              INVENTORY REPORT                                  ");
            Console.WriteLine("================================================================================");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(
                "Name".PadRight(40) +
                "ID".PadRight(20) +
                "Quantity".PadRight(15) +
                "Price".PadRight(15)
            );

            Console.ResetColor();

            Console.WriteLine("--------------------------------------------------------------------------------");


            foreach (ProductClass product in Products)
            {
                Console.WriteLine(product);
            }

            decimal total = 0;
            foreach (ProductClass product in Products)
            {
                total += product.Price.Value * product.Quantity.Value;
            }

            Console.WriteLine();
          
            //Console.Write("Total inventory value is: ");
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine($"{ total} kr");
            //Console.ResetColor();

            // Code for checking the most expensive and cheapest product

            ProductClass expensiveProduct = Products.OrderByDescending(p => p.Price).FirstOrDefault();
            ProductClass cheapestProduct = Products.OrderBy(p => p.Price).FirstOrDefault();

            //Console.WriteLine($"Most expensive product: {expensiveProduct.Name} - {expensiveProduct.Price} kr");
            //Console.WriteLine($"Cheapest product: {cheapestProduct.Name} - {cheapestProduct.Price} kr");

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("================================================================================");
            Console.WriteLine("                              INVENTORY STATISTICS                              ");
            Console.WriteLine("================================================================================");

            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Total Inventory Value: ".PadRight(35));

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{total:N0} kr");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Most Expensive Product: ".PadRight(35));

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{expensiveProduct.Name} ({expensiveProduct.Price} kr)");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("Cheapest Product: ".PadRight(35));

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"{cheapestProduct.Name} ({cheapestProduct.Price} kr)");

            Console.ResetColor();

            // Low Stock Products

            var lowOnStock = Products.Where(p => p.Quantity <= 5);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("================================================================================");
            Console.WriteLine("                               LOW STOCK PRODUCTS                               ");
            Console.WriteLine("================================================================================");

            Console.ResetColor();

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(
                "Product Name".PadRight(40) +
                "Quantity In Stock".PadLeft(20)
            );

            Console.ResetColor();

            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Red;

            foreach (ProductClass product in lowOnStock)
            {
                
                Console.Write($"{product.Name.PadRight(40)}");
                
                
                
                Console.WriteLine($"{product.Quantity.ToString().PadLeft(10)}");
               

            }

            Console.ResetColor();

        }

        public void SaveToFile()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string json = 
                JsonSerializer.Serialize( Products, options );

            File.WriteAllText("products.json", json);
            
        }

        public void LoadFromFile()
        {
            if (!File.Exists("products.json"))
            {
                return;
            }

            string json =
                File.ReadAllText("products.json");

            Products =
                JsonSerializer.Deserialize<List<ProductClass>>(json) 
                ?? new List<ProductClass>();

        }










    }
    
}
