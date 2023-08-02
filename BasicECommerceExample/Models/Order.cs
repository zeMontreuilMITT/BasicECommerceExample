namespace BasicECommerceExample.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public HashSet<OrderProduct> OrderedProducts { get; set; } = new HashSet<OrderProduct>();
        public Customer Customer { get; set; }
        public Guid CustomerAccountNumber { get; set; }
        public Address Address { get; set; }
        public Guid AddressId { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Shipped,
        Received
    }
}
