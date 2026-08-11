using ContactApp.Model;

namespace ContactApp.Repository
{
    // Defines contact data operations contract
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Add(Contact contact);
        void Update(int id, Contact contact);
        void Delete(int id);
    }
}