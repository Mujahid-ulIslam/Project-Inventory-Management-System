


using Project_Inventory_Management_System;

List<ProductClass> products = new List<ProductClass>();
//{
//    new ProductClass("P101", "Dell XPS 15", 5, 1800),
//    new ProductClass("P102", "MacBook Air M3", 3, 1500),
//    new ProductClass("P103", "Logitech Mouse", 15, 40),
//    new ProductClass("P104", "Mechanical Keyboard", 8, 120),
//    new ProductClass("P105", "Samsung Monitor 27\"", 6, 300),
//    new ProductClass("P106", "PlayStation 5", 4, 600),
//    new ProductClass("P107", "Xbox Series X", 2, 550),
//    new ProductClass("P108", "iPhone 15 Pro", 7, 1300),
//    new ProductClass("P109", "USB-C Charger", 20, 25),
//    new ProductClass("P110", "Noise Cancelling Headphones", 5, 250)
//};


InventoryClass inventory = new InventoryClass(products);
inventory.LoadFromFile();



while (true) 
{
    
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.WriteLine("======================================================");
    Console.WriteLine("              INVENTORY MANAGEMENT SYSTEM             ");
    Console.WriteLine("======================================================");

    Console.ResetColor();

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine("[1] Add Product");
    Console.WriteLine("[2] Update Product");
    Console.WriteLine("[3] Delete Product");
    Console.WriteLine("[4] View Products");
    Console.WriteLine("[5] Generate Report");
    Console.WriteLine("[6] Exit");

    Console.ResetColor();

    Console.WriteLine();

    Console.WriteLine("---------------------------------------------");
    Console.WriteLine("Type 'q' at any input to cancel the operation.");
    Console.WriteLine("---------------------------------------------");

    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.Write("Select an option: ");

    Console.ResetColor();

    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            Console.Clear();            
            if (inventory.AddProducts())
            {
                inventory.SaveToFile();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            break;

        case "2":
            Console.Clear();
            if (inventory.UpdateProducts())
            {
                inventory.SaveToFile();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            break;

        case "3":
            Console.Clear();
            if (inventory.DeleteProducts())
            {
                inventory.SaveToFile();
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            break;

        case "4":
            Console.Clear();
            inventory.ShowProducts();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            break;

        case "5":
            Console.Clear();
            inventory.GenerateReport();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            break;


        case "6":

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("======================================================");
            Console.WriteLine("     Thank you for using Inventory Management System! ");
            Console.WriteLine("======================================================");

            Console.ResetColor();

            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
    

}

