var builder = WebApplication.CreateBuilder(args);

// Add controllers support
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controller routes
app.MapControllers();

app.Run();