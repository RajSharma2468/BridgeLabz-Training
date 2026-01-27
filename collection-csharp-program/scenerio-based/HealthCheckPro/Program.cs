var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<HealthCheckProService>();

var app = builder.Build();

app.MapControllers();

app.Run();
