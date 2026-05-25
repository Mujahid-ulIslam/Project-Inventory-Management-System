


using Project_Inventory_Management_System;

List<ProductClass> products = new List<ProductClass>();
InventoryClass inventory = new InventoryClass(products);

////bool running  = true;

////while (running)
////{
////    while (inventory.AddProduct())
////    {

////    }

////    Console.Clear();    // Clears console for cleaner UI
//}




Console.WriteLine("1. Add a product");
Console.WriteLine("2. Update a product");
Console.WriteLine("3. Delete a product");
Console.WriteLine("4. View all product");
Console.WriteLine("5. Generate a report");
Console.WriteLine("6. Exit the application");
Console.Write("Choose option: ");
string userInput = Console.ReadLine();

switch (userInput)
{
    case "1":
        Console.WriteLine("You chose Add Product");
        while (inventory.AddProduct())
        {

        }
        break;

    case "2":
        Console.WriteLine("You chose Update Product.");
        break;

}