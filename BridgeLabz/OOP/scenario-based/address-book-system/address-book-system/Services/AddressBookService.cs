using System.Collections.Generic;
using System.Threading.Tasks;
using AddressBookSystem.Models;
using AddressBookSystem.Interfaces;

namespace AddressBookSystem.Services
{
    public class AddressBookService
    {
        private readonly IDataSource _dataSource;

        public AddressBookService()
        {
            _dataSource = new DatabaseDataSource();
        }

        public Task AddContactAsync(Contact contact)
        {
            return _dataSource.AddContactAsync(contact);
        }

        public Task<List<Contact>> GetAllContactsAsync()
        {
            return _dataSource.GetAllContactsAsync();
        }

        public Task UpdateContactAsync(Contact contact)
        {
            return _dataSource.UpdateContactAsync(contact);
        }

        public Task DeleteContactAsync(int id)
        {
            return _dataSource.DeleteContactAsync(id);
        }
    }
}
