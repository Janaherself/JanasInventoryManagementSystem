using Dapper;
using System.Data;

namespace JanasInventoryManagementSystem
{
    public class SQLInventory
    {
        public static void InsertProduct(Product product)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.Connection("InventoryDB")))
            {
                List<Product> products = new List<Product>();

                products.Add(product);

                connection.Execute("dbo.sp_InsertItem @Name, @Price, @Quantity", products);
            }
        }

        public static void ViewProducts()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.Connection("InventoryDB")))
            {
                var products = connection.Query<Product>("dbo.sp_ViewItems");
                printProducts(products);

            }

        }

        public static void UpdateProduct(int productId)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.Connection("InventoryDB")))
            {
                Console.Write("Enter new product name: ");
                string? name = Console.ReadLine();

                Console.Write("Enter new product price: ");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Enter new product quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                connection.Execute("dbo.sp_UpdateItem @Id, @Name, @Price, @Quantity", new { Id = productId, Name = name, Price = price, Quantity = quantity});
            }
        }


        public static void DeleteProduct(int ID)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.Connection("InventoryDB")))
            {
                connection.Execute("dbo.sp_DeleteItem @ItemId", new { ItemId = ID });
            }
        }

        public static void GetProduct(string itemName)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(ConnectionHelper.Connection("InventoryDB")))
            {
                var products = connection.Query<Product>("dbo.sp_GetItemByName @Name", new { Name = itemName });
                printProducts(products);
            }
        }

        public static void ExitFromConsole()
        {
            Console.WriteLine("Exiting..\n");
        }

        private static void printProducts(IEnumerable<Product> products)
        {
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}. {product.Name}\n" +
                                  $"Quantity: {product.Quantity}\n" +
                                  $"Price: {product.Price}\n");
            }
        }
    }
}
