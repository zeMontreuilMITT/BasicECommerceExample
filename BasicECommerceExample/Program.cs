using BasicECommerceExample.Data;
using BasicECommerceExample.Models;
using BasicECommerceExample.Models.ResponseModel;
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

app.MapGet("/customers/all", (ECommerceContext db) =>
{
    // show all customers, then show a list of addresses


    // get all customers
    // Select: get some customer property values and insert them into a new object (in this case, a new CustomerWithAddresses object
    HashSet<CustomerWithAddresses> CustomersWAddresses = db.Customers.Select(c => new CustomerWithAddresses {
            CustomerId = c.Id, 
            CustomerFullName = c.FullName, 
            AddressList = c.CustomerAddresses.Select(ca => ca.Address).ToHashSet()
        }).ToHashSet();

    return Results.Ok(CustomersWAddresses);
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

app.Run();

// Customer = new Customer { Id = 2, Name = "test" }