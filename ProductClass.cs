using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Inventory_Management_System
{
    internal class ProductClass
    {
        public ProductClass(string id)
        {
            Id = id;
        }

        public ProductClass(string id, string name, int? quantity, decimal? price) : this(id)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public void DisplayProductInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Product Name: {Name}, ID: {Id}, Quantity: {Quantity}, Price: {Price}");
            Console.ResetColor();
        }


    }
}
