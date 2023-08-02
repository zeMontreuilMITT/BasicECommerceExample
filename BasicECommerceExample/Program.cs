using BasicECommerceExample.Data;
using BasicECommerceExample.Models;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ECommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceConnectionString"));
});

builder.Services.Configure<JsonOptions>(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider serviceProvider = scope.ServiceProvider;

    await SeedData.Initialize(serviceProvider);
}

app.MapGet("/customers/all", (ECommerceContext db) =>
{
    return Results.Ok(db.Customers
        .Include(c => c.PrimaryAddress)
        .Include(c => c.SecondaryAddress)
        .ToHashSet());

    // .Include refers to initially queried table
    // .ThenInclude refers to the most recently queried table on an Include series
});

app.MapPost("/products/create", (ECommerceContext db, string name) => {
    try
    {
        if (db.Products.Any(p => p.Name.ToLower().Equals(name.ToLower())))
        {
            return Results.Conflict($"Product with name '{name}' already exists.");
        }

        Product newProduct = new Product { Name  = name };
        
        db.Products.Add(newProduct);
        db.SaveChanges();

        Console.WriteLine(newProduct.Id);
        return Results.Created($"/products/{newProduct.Id}", newProduct);
    } catch (Exception ex)
    {
        return Results.BadRequest(ex.Message);
    }
 
});

app.MapPost("/cart/{orderNumber}/add", (ECommerceContext db, Guid itemId, int quantity, Guid orderNumber) =>
{
    try
    {
        if (quantity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity));
        }

        // comparing Guid 
        Order order = db.Orders.Include(o => o.OrderedProducts).First(o => o.Id.CompareTo(orderNumber) == 0);

        if(!order.OrderStatus.Equals(OrderStatus.Pending))
        {
            throw new InvalidOperationException("Cannot add product to Order that is not Pending.");
        }

        Product product = db.Products.First(p => p.Id.CompareTo(itemId) == 0);

        // if order already contains product, then increment product quantity instead
        OrderProduct? preexistingOrderProduct = order.OrderedProducts.FirstOrDefault(op => op.ProductId.CompareTo(product.Id) == 0);

        if(preexistingOrderProduct != null)
        {
            preexistingOrderProduct.Quantity += quantity;
        }
        else
        {
            order.OrderedProducts.Add(new OrderProduct { Product = product, Quantity = quantity });
        }

        db.SaveChanges();
        return Results.Ok(order);

    } catch (InvalidOperationException ex)
    {
        return Results.NotFound(ex.Message);
    }
});

app.Run();
