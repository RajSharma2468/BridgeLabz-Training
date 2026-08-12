using ContactAppEF.Model;
using ContactAppEF.Repository;
using ContactAppEF.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ContactAppDB_EF;Trusted_Connection=True;TrustServerCertificate=True;"));

builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

app.MapGet("/contacts", (IContactRepository repo) =>
{
    return Results.Ok(repo.GetAll());
});

app.MapGet("/contacts/{id}", (int id, IContactRepository repo) =>
{
    var contact = repo.GetById(id);
    if (contact == null)
        return Results.NotFound($"Contact with id {id} not found.");

    return Results.Ok(contact);
});

app.MapPost("/contacts", (Contact contact, IContactRepository repo) =>
{
    repo.Add(contact);
    return Results.Ok("Contact created successfully.");
});

app.MapPut("/contacts/{id}", (int id, Contact contact, IContactRepository repo) =>
{
    repo.Update(id, contact);
    return Results.Ok("Contact updated successfully.");
});

app.MapDelete("/contacts/{id}", (int id, IContactRepository repo) =>
{
    repo.Delete(id);
    return Results.Ok("Contact deleted successfully.");
});

app.Run();