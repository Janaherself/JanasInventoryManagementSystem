namespace JanasInventoryManagementSystem
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }


        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public Product()
        {
            
        }
    }
}
