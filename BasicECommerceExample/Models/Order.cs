namespace BasicECommerceExample.Models
{
    public class Order
    { 
        public Guid Id { get; set; }
        private int _quantity;
        public int Quantity { 
            get => _quantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                } else
                {
                    _quantity = value;
                }
            }
        }

        public CustomerAddress CustomerAddress { get; set; }
        public Guid CustomerAddressId { get; set; }

        public Product Product { get; set; }
        public Guid ProductId {  get; set; }
    }
}
