using Microsoft.EntityFrameworkCore;
using FundooNotes.Repository;
using FundooNotes.Repository.Data;
using FundooNotes.Business;

var builder =
    WebApplication.CreateBuilder(args);


// ----------------------------------------------------
// DATABASE CONFIGURATION
// ----------------------------------------------------

// Read SQL Server connection string
// from appsettings.json.
var connectionString =
    builder.Configuration.GetConnectionString(
        "DefaultConnection");


// Register Controllers.
builder.Services.AddControllers();


// Register Swagger.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ----------------------------------------------------
// DEPENDENCY INJECTION / IOC
// ----------------------------------------------------

// Register DbContext.
// ASP.NET Core will create AppDbContext automatically
// whenever Repository needs it.
builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseSqlServer(connectionString));


// Register Repository.
// Whenever INoteRepository is requested,
// ASP.NET Core creates NoteRepository.
builder.Services.AddScoped<
    INoteRepository,
    NoteRepository>();


// Register Business layer.
// Whenever INoteBusiness is requested,
// ASP.NET Core creates NoteBusiness.
builder.Services.AddScoped<
    INoteBusiness,
    NoteBusiness>();


// Register Email service.
// Whenever IEmailService is requested,
// ASP.NET Core creates EmailService.
builder.Services.AddScoped<
    IEmailService,
    EmailService>();


// Build application.
var app = builder.Build();


// ----------------------------------------------------
// HTTP PIPELINE
// ----------------------------------------------------

if (app.Environment.IsDevelopment())
{
    // Enable Swagger.
    app.UseSwagger();

    app.UseSwaggerUI();
}


// Redirect HTTP requests to HTTPS.
app.UseHttpsRedirection();


// Authorization middleware.
app.UseAuthorization();


// Map controller routes.
app.MapControllers();


// Start application.
app.Run();