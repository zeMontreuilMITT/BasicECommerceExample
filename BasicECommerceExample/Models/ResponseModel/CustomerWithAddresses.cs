namespace BasicECommerceExample.Models.ResponseModel
{
    public class CustomerWithAddresses
    {
        public Guid CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public HashSet<Address> AddressList { get; set; }
    }
}
