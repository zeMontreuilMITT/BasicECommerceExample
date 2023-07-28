namespace BasicECommerceExample.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HashSet<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
