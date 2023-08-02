namespace BasicECommerceExample.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                else
                {
                    _quantity = value;
                }
            }
        }

        public Product Product { get; set; }
        public Guid ProductId { get; set; }

        public Customer Customer { get; set; }
        public Guid CustomerAccountNumber { get; set; }

        // could include the Address as a navigational property
        // endpoints (or Business Logic Layer) will control making sure that the address is set for the same customer
        public Address Address { get; set; }
        public Guid AddressId { get; set; }
    }
}
