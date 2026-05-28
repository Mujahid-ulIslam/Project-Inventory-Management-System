


using Project_Inventory_Management_System;

List<ProductClass> products = new List<ProductClass>()
{
    new ProductClass("P101", "Dell XPS 15", 5, 1800),
    new ProductClass("P102", "MacBook Air M3", 3, 1500),
    new ProductClass("P103", "Logitech Mouse", 15, 40),
    new ProductClass("P104", "Mechanical Keyboard", 8, 120),
    new ProductClass("P105", "Samsung Monitor 27\"", 6, 300),
    new ProductClass("P106", "PlayStation 5", 4, 600),
    new ProductClass("P107", "Xbox Series X", 2, 550),
    new ProductClass("P108", "iPhone 15 Pro", 7, 1300),
    new ProductClass("P109", "USB-C Charger", 20, 25),
    new ProductClass("P110", "Noise Cancelling Headphones", 5, 250)
};


InventoryClass inventory = new InventoryClass(products);
inventory.LoadFromFile();



while (true) 
{ 

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("1. Add a product");
    Console.WriteLine("2. Update a product");
    Console.WriteLine("3. Delete a product");
    Console.WriteLine("4. View all product");
    Console.WriteLine("5. Generate a report");
    Console.WriteLine("6. Exit the application");
    Console.WriteLine("Enter 'q' to go back to the main menu.");
    Console.WriteLine();
    Console.Write("Choose option: ");
    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            Console.Clear();
            if (inventory.AddProducts())
            {
                inventory.SaveToFile();
            }        
            break;

        case "2":

            Console.Clear();
            if (inventory.UpdateProducts())
            {
                inventory.SaveToFile();
            }
            break;

        case "3":
            Console.Clear();
            if (inventory.DeleteProducts())
            {
                inventory.SaveToFile();
            }
            break;

        case "4":
            Console.Clear();
            inventory.ShowProducts();
            break;

        case "5":
            Console.Clear();
            inventory.GenerateReport();
            break;


        case "6":
            return;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
    

}

