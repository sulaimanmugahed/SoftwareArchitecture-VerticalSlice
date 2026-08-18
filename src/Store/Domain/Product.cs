
namespace Store.Domain
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        private Product()
        {

        }
        private Product(string name, decimal price, int categoryId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }


        public static Product Create(string name, decimal price, int categoryId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("product name cant be null or empty");
            }

            if (price <= 0)
            {
                throw new ArgumentException("price Should be positive");
            }
            return new Product(name, price, categoryId);
        }

        public decimal GetTotalPrice(int quantity)
        {
            return Price * quantity;
        }

        public void DecreaseQuantity(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("quantity must be greater than zero");

            if (Quantity < quantity)
                throw new InvalidOperationException($"not enough stock, Available: {Quantity}");

            Quantity -= quantity;
        }

        public void ReStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("quantity must be greater than zero");

            Quantity += quantity;
        }
    }
}