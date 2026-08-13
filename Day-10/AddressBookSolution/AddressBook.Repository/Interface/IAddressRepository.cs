using AddressBook.Model.Entities;

namespace AddressBook.Repository
{
    // Defines address entry data operations
    public interface IAddressRepository
    {
        List<AddressEntry> GetAll();
        AddressEntry GetById(int id);
        void Add(AddressEntry entry);
        void Update(int id, AddressEntry entry);
        void Delete(int id);
    }
}