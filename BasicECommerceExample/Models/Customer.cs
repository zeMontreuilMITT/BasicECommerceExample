namespace BasicECommerceExample.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        private string _fullName;
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                else
                {
                    _fullName = value;
                }
            }
        }
        public HashSet<CustomerAddress> CustomerAddresses { get; set; } = new HashSet<CustomerAddress>();

        public Customer(string fullName)
        {
            FullName = fullName;
        }

        public Customer()
        {

        }
    }
}
