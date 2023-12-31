﻿namespace BasicECommerceExample.Models
{
    public class Customer
    {
        public Guid AccountNumber { get; set; }
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

        public Guid PrimaryAddressId { get; set; }
        public Address PrimaryAddress { get; set; }

        public Guid? SecondaryAddressId { get; set; }
        public Address? SecondaryAddress { get; set; }

        public HashSet<Order> Orders { get; set; } = new HashSet<Order>();

        public Customer(string fullName)
        {
            FullName = fullName;
        }

        public Customer()
        {

        }
    }
}
