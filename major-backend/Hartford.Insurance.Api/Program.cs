using Hartford.Insurance.Api.Data;
using Hartford.Insurance.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// MongoDB Context
builder.Services.AddSingleton<MongoDbContext>();

// Services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<InsuranceRequestService>();
builder.Services.AddScoped<PolicyRecommendationService>();
builder.Services.AddScoped<PolicyApplicationService>();
builder.Services.AddScoped<PolicyService>();
builder.Services.AddScoped<ClaimService>();
builder.Services.AddScoped<AgentService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<NotificationService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Use original property names (or camelCase if desired, but default is camelCase)
        // Actually, default is camelCase. If current JSON has "Name": "John", we might need Pascal.
        // But common JS frameworks expect camelCase.
        // User said: "Collections must match JSON structure names". Usually implies fields too.
        // I'll stick to default camelCase.
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200", "http://localhost:3000") // Angular default 4200, JSON server was 3000. Assuming frontend might be on 4200.
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Data Seeding
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<MongoDbContext>();
        var seeder = new DbSeeder(context);
        await seeder.SeedAsync();
    }
}

app.UseCors("AllowAngularDev");

app.UseAuthorization();

app.MapControllers();

app.Run();
