namespace BasicECommerceExample.Models
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid AddressId { get; set; }
        public bool PrimaryAddress { get; set; }

        public Customer Customer { get; set; }
        public Address Address { get; set; }
    }
}
