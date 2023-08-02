using BasicECommerceExample.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerceExample.Data
{
    public static class SeedData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            ECommerceContext db = new ECommerceContext(serviceProvider.GetRequiredService<DbContextOptions<ECommerceContext>>());

            db.Database.EnsureDeleted();
            db.Database.Migrate();


            // ADDRESS
            Address addressOne = new Address { StreetAndNumber = "444 Fake st." };

            if (!db.Addresses.Any())
            {
                db.Add(addressOne);
                db.SaveChanges();
            }

            // CUSTOMER
            Customer customerOne = new Customer("First Test Customer");
            Customer customerTwo = new Customer("Second Test Customer");

            customerOne.PrimaryAddress = addressOne;
            customerTwo.PrimaryAddress = addressOne;

            if (!db.Customers.Any())
            {
                db.Add(customerOne);
                db.Add(customerTwo);
                db.SaveChanges();
            }
            
            Order firstOrder = new Order { Address = addressOne, Customer = customerTwo, OrderStatus = OrderStatus.Pending };
            Order secondOrder = new Order { Address = addressOne, Customer = customerTwo, OrderStatus = OrderStatus.Shipped };

            if (!db.Orders.Any())
            {
                db.Add(firstOrder);
                db.Add(secondOrder);
                db.SaveChanges();
            }

            Product firstProduct = new Product { Name = "Furby" };
            Product secondProduct = new Product { Name = "Pet Rock" };
            Product thirdProduct = new Product { Name = "Tamagotchi" };

            if (!db.Products.Any())
            {
                db.Add(firstProduct);
                db.Add(secondProduct);
                db.Add(thirdProduct);
                db.SaveChanges();
            }
        }
    }
}
