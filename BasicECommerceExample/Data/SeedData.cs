using BasicECommerceExample.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerceExample.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            ECommerceContext db = new ECommerceContext(serviceProvider.GetRequiredService<DbContextOptions<ECommerceContext>>());

            // CUSTOMER
            Customer customerOne = new Customer("First Test Customer");
            Customer customerTwo = new Customer("Second Test Customer");

            db.Database.EnsureDeleted();
            db.Database.Migrate();


            if (!db.Customers.Any())
            {
                db.Add(customerOne);
                db.Add(customerTwo);
                db.SaveChanges();
            }

            // ADDRESS
            Address addressOne = new Address { StreetAndNumber = "444 Fake st." };

            if (!db.Addresses.Any())
            {
                db.Add(addressOne);
                db.SaveChanges();
            }


        }
    }
}
