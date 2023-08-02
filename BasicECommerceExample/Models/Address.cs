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


        // must specify "inverse properties" on these navigational properties
        // we have to configure which relationship on the related object each of these navigation properties refers to
        public HashSet<Customer> PrimaryCustomers { get; set; } = new HashSet<Customer>();
        public HashSet<Customer> SecondaryCustomers { get; set; } = new HashSet<Customer>();
    }
}
