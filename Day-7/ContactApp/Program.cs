using ContactApp.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory storage for contacts
List<Contact> contacts = new List<Contact>();
int nextId = 1;

// GET all contacts
app.MapGet("/contacts", () =>
{
    return Results.Ok(contacts);
});

// GET contact by id
app.MapGet("/contacts/{id}", (int id) =>
{
    var contact = contacts.FirstOrDefault(c => c.ContactId == id);

    if (contact == null)
        return Results.NotFound($"Contact with id {id} not found.");

    return Results.Ok(contact);
});

// POST create new contact
app.MapPost("/contacts", (Contact contact) =>
{
    contact.ContactId = nextId;
    nextId++;

    contacts.Add(contact);
    return Results.Ok("Contact created successfully.");
});

// PUT update existing contact
app.MapPut("/contacts/{id}", (int id, Contact updatedContact) =>
{
    var contact = contacts.FirstOrDefault(c => c.ContactId == id);

    if (contact == null)
        return Results.NotFound($"Contact with id {id} not found.");

    contact.Name = updatedContact.Name;
    contact.Phone = updatedContact.Phone;
    contact.Email = updatedContact.Email;

    return Results.Ok("Contact updated successfully.");
});

// DELETE remove a contact
app.MapDelete("/contacts/{id}", (int id) =>
{
    var contact = contacts.FirstOrDefault(c => c.ContactId == id);

    if (contact == null)
        return Results.NotFound($"Contact with id {id} not found.");

    contacts.Remove(contact);
    return Results.Ok("Contact deleted successfully.");
});

app.Run();