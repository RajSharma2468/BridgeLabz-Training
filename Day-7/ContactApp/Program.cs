using ContactApp.Model;
using ContactApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Register repository for dependency injection
builder.Services.AddScoped<IContactRepository, ContactRepository>();

var app = builder.Build();

// GET all contacts
app.MapGet("/contacts", (IContactRepository repo) =>
{
    return Results.Ok(repo.GetAll());
});

// GET contact by id
app.MapGet("/contacts/{id}", (int id, IContactRepository repo) =>
{
    var contact = repo.GetById(id);
    if (contact == null)
        return Results.NotFound($"Contact with id {id} not found.");

    return Results.Ok(contact);
});

// POST create new contact
app.MapPost("/contacts", (Contact contact, IContactRepository repo) =>
{
    repo.Add(contact);
    return Results.Ok("Contact created successfully.");
});

// PUT update existing contact
app.MapPut("/contacts/{id}", (int id, Contact contact, IContactRepository repo) =>
{
    repo.Update(id, contact);
    return Results.Ok("Contact updated successfully.");
});

// DELETE remove a contact
app.MapDelete("/contacts/{id}", (int id, IContactRepository repo) =>
{
    repo.Delete(id);
    return Results.Ok("Contact deleted successfully.");
});

app.Run();