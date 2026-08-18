
namespace Store.Domain
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Balance { get; private set; }

        private Customer()
        {

        }
        private Customer(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
        }

        public static Customer Create(string name, decimal balance)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("customer name cant be null or empty");
            }

            return new Customer(name, balance);
        }

        public void ReduceBalance(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("amount must be greater than zero");

            if (Balance < amount)
                throw new InvalidOperationException($"unAvailable balance ({amount}) , Available: {Balance}");

            Balance -= amount;
        }

    }
}