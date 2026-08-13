using Microsoft.EntityFrameworkCore;
using AddressBook.Repository;
using AddressBook.Repository.Data;
using AddressBook.Business;

var builder = WebApplication.CreateBuilder(args);

// Read connection string from appsettings.json
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register controllers
builder.Services.AddControllers();

// Register EF Core DbContext with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register repository layer
builder.Services.AddScoped<IAddressRepository, AddressRepository>();

// Register business layer
builder.Services.AddScoped<IAddressBusiness, AddressBusiness>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();