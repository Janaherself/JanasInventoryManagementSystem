namespace JanasInventoryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new();
            DataManager dataManager = new();
            SQLInventory sqlInventory = new();

            bool exit = true;

            while (exit) 
            {
                Console.WriteLine("Welcome To Jana's Inventory Management system!\n" +
                    "You can choose one of the options below by typing its corresponding number.\n" +
                    "1. Add a Product\n" +
                    "2. View a List of Products\n" +
                    "3. Edit a Product\n" +
                    "4. Delete a Product\n" +
                    "5. Search for a Product\n" +
                    "6. Exit The App\n");
                Console.Write("Select an Option: ");

                string? option = Console.ReadLine();

                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        var product = dataManager.ReadFromConsole();
                        SQLInventory.InsertProduct(product);
                        break;
                    case "2":
                        SQLInventory.ViewProducts();
                        break;
                    case "3":
                        int idToEdit = dataManager.GetId();
                        SQLInventory.UpdateProduct(idToEdit);
                        break;
                    case "4":
                        int idToDelete = dataManager.GetId();
                        SQLInventory.DeleteProduct(idToDelete);
                        break;
                    case "5":
                        string itemToSearchFor = dataManager.GetName();
                        SQLInventory.GetProduct(itemToSearchFor);
                        break;
                    case "6":
                        SQLInventory.ExitFromConsole();
                        exit = false;
                        break;
                    default: 
                        Console.WriteLine("Invalid Option! Try Again Please.\n");
                        break;
                }
            }
        }
    }
}
