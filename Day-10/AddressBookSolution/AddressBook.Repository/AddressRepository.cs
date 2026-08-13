using AddressBook.Model.Entities;
using AddressBook.Repository.Data;

namespace AddressBook.Repository
{
    // Implements address data access using EF Core ORM
    public class AddressRepository : IAddressRepository
    {
        // DbContext instance injected here
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        // Fetches all address entries
        public List<AddressEntry> GetAll()
        {
            return _context.AddressBookEntries.ToList();
        }

        // Fetches single entry by id
        public AddressEntry GetById(int id)
        {
            return _context.AddressBookEntries.Find(id);
        }

        // Inserts new address entry
        public void Add(AddressEntry entry)
        {
            _context.AddressBookEntries.Add(entry);
            _context.SaveChanges();
        }

        // Updates existing address entry
        public void Update(int id, AddressEntry updatedEntry)
        {
            var entry = _context.AddressBookEntries.Find(id);
            if (entry != null)
            {
                entry.Name = updatedEntry.Name;
                entry.Phone = updatedEntry.Phone;
                entry.Email = updatedEntry.Email;
                entry.Address = updatedEntry.Address;
                _context.SaveChanges();
            }
        }

        // Deletes an address entry
        public void Delete(int id)
        {
            var entry = _context.AddressBookEntries.Find(id);
            if (entry != null)
            {
                _context.AddressBookEntries.Remove(entry);
                _context.SaveChanges();
            }
        }
    }
}