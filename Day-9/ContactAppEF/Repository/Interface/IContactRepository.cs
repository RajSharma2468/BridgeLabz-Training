using ContactAppEF.Model;

namespace ContactAppEF.Repository
{
    public interface IContactRepository
    {
        List<Contact> GetAll();
        Contact GetById(int id);
        void Add(Contact contact);
        void Update(int id, Contact contact);
        void Delete(int id);
    }
}