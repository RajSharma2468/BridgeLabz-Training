using AddressBook.Model.Entities;

namespace AddressBook.Business
{
    // Defines business operations contract
    public interface IAddressBusiness
    {
        List<AddressEntry> GetAllEntries();
        AddressEntry GetEntryById(int id);
        void AddEntry(AddressEntry entry);
        void UpdateEntry(int id, AddressEntry entry);
        void DeleteEntry(int id);
    }
}