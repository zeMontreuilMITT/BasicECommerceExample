using BasicECommerceExample.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerceExample.Data
{
    public class ECommerceContext: DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // inverse property: we must specify which navigational properties refer to which specific relationship on the other side 
            modelBuilder.Entity<Customer>()
                .HasOne(c => c.PrimaryAddress)
                .WithMany(a => a.PrimaryCustomers)
                .HasForeignKey(c => c.PrimaryAddressId);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.SecondaryAddress)
                .WithMany(a => a.SecondaryCustomers)
                .HasForeignKey(c => c.SecondaryAddressId);
        }


        public ECommerceContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;    
    }
}
