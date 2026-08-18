

namespace Store.Domain
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private Category()
        {

        }
        private Category(string name)
        {
            Name = name;
        }

        public static Category Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("category name cant be null or empty");
            }

            return new Category(name);
        }
    }
}