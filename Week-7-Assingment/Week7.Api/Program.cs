using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using CustomerOrderAPIDemo.Data;
using CustomerOrderAPIDemo.Models;



var builder = WebApplication.CreateBuilder(args);

// Add Controllers + Fix Circular JSON issue
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// InMemory Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("Week7Db"));

var app = builder.Build();

// Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


// 🔥 SEED DATA
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Customers.Any())
    {
        var customer1 = new Customer
        {
            Name = "John Doe",
            Email = "john@example.com",
            Phone = "1234567890"
        };

        var customer2 = new Customer
        {
            Name = "Jane Smith",
            Email = "jane@example.com",
            Phone = "9876543210"
        };

        context.Customers.AddRange(customer1, customer2);
        context.SaveChanges();

        context.Orders.AddRange(
            new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = 500,
                CustomerId = customer1.Id
            },
            new Order
            {
                OrderDate = DateTime.Now,
                TotalAmount = 1200,
                CustomerId = customer2.Id
            }
        );

        context.SaveChanges();
    }
}

app.Run();
