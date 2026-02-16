using Microsoft.EntityFrameworkCore;
using Week7.Api.Data;
using Week7.Api.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("Week7Db"));

var app = builder.Build();

// Enable Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Seed Data
// Seed Data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Customers.Any())
    {
        var customer1 = new Customer
        {
            Id = 1,
            Name = "John Doe",
            Email = "john@example.com"
        };

        var customer2 = new Customer
        {
            Id = 2,
            Name = "Jane Smith",
            Email = "jane@example.com"
        };

        context.Customers.AddRange(customer1, customer2);

        context.Orders.AddRange(
            new Order
            {
                Id = 1,
                OrderDate = DateTime.Now,
                TotalAmount = 500,
                CustomerId = 1
            },
            new Order
            {
                Id = 2,
                OrderDate = DateTime.Now,
                TotalAmount = 1200,
                CustomerId = 2
            }
        );

        context.SaveChanges();
    }
}

app.Run();
