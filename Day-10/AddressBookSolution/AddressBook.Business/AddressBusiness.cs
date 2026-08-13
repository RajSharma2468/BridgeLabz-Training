using AddressBook.Model.Entities;
using AddressBook.Model.Exceptions;
using AddressBook.Repository;

namespace AddressBook.Business
{
    // Handles business logic and validation
    public class AddressBusiness : IAddressBusiness
    {
        // Repository instance used here
        private readonly IAddressRepository _repository;

        public AddressBusiness(IAddressRepository repository)
        {
            _repository = repository;
        }

        // Returns all entries
        public List<AddressEntry> GetAllEntries()
        {
            return _repository.GetAll();
        }

        // Returns single entry by id
        public AddressEntry GetEntryById(int id)
        {
            var entry = _repository.GetById(id);
            if (entry == null)
                throw new EntryNotFoundException($"Entry with id {id} not found.");

            return entry;
        }

        // Validates and adds new entry
        public void AddEntry(AddressEntry entry)
        {
            // Business validation before insert
            if (string.IsNullOrWhiteSpace(entry.Name))
                throw new ValidationException("Name cannot be empty.");

            if (string.IsNullOrWhiteSpace(entry.Phone))
                throw new ValidationException("Phone cannot be empty.");

            _repository.Add(entry);
        }

        // Validates and updates entry
        public void UpdateEntry(int id, AddressEntry entry)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                throw new EntryNotFoundException($"Entry with id {id} not found.");

            if (string.IsNullOrWhiteSpace(entry.Name))
                throw new ValidationException("Name cannot be empty.");

            _repository.Update(id, entry);
        }

        // Deletes entry after existence check
        public void DeleteEntry(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null)
                throw new EntryNotFoundException($"Entry with id {id} not found.");

            _repository.Delete(id);
        }
    }
}