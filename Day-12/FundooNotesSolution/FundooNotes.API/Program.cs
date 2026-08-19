using Microsoft.EntityFrameworkCore;
using FundooNotes.Repository;
using FundooNotes.Repository.Data;
using FundooNotes.Business;

// Creates the application builder
var builder = WebApplication.CreateBuilder(args);

// Reads database connection string
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registers MVC controllers
builder.Services.AddControllers();

// Enables API endpoint explorer
builder.Services.AddEndpointsApiExplorer();

// Configures Swagger documentation generator
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Fundoo Notes API",
        Version = "v1",
        Description = "User Management and Notes Module"
    });
});

// Registers EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Registers HttpClient factory service
builder.Services.AddHttpClient();

// Registers user repository dependency
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Registers user business dependency
builder.Services.AddScoped<IUserBusiness, UserBusiness>();

// Registers note repository dependency
builder.Services.AddScoped<INoteRepository, NoteRepository>();

// Registers note business dependency
builder.Services.AddScoped<INoteBusiness, NoteBusiness>();

// Builds the application instance
var app = builder.Build();

// Enables Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Fundoo Notes API v1");
    });
}

// Redirects HTTP to HTTPS
app.UseHttpsRedirection();

// Enables authorization middleware
app.UseAuthorization();

// Maps controller endpoint routes
app.MapControllers();

// Starts the application
app.Run();