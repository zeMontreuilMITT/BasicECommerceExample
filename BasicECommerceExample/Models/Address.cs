namespace BasicECommerceExample.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        private string _streetAndNumber;
        public string StreetAndNumber
        {
            get
            {
                return _streetAndNumber;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                else
                {
                    _streetAndNumber = value;
                }
            }
        }

        public HashSet<CustomerAddress> CustomerAddresses = new HashSet<CustomerAddress>();
    }
}
