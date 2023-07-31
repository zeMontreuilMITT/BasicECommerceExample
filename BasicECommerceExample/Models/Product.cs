namespace BasicECommerceExample.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        private string _name;
        public string Name { get => _name;
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                else
                {
                    _name = value;
                }
            }
        }
        public HashSet<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
