using AddressBook.CleanApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Register Service
builder.Services.AddScoped<IAddressBookService, AddressBookService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
