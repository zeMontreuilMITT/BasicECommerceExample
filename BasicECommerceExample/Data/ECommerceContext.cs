using BasicECommerceExample.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerceExample.Data
{
    public class ECommerceContext: DbContext
    {
        public ECommerceContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<CustomerAddress> CustomersAddresses { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;    
    }
}
