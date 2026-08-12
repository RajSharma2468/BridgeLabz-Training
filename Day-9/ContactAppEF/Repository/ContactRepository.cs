using ContactAppEF.Model;
using ContactAppEF.Data;

namespace ContactAppEF.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public Contact GetById(int id)
        {
            return _context.Contacts.Find(id);
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void Update(int id, Contact updatedContact)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                contact.Name = updatedContact.Name;
                contact.Phone = updatedContact.Phone;
                contact.Email = updatedContact.Email;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }
    }
}