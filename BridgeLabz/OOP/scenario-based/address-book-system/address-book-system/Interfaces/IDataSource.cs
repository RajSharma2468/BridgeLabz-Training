using System.Collections.Generic;
using System.Threading.Tasks;
using AddressBookSystem.Models;

namespace AddressBookSystem.Interfaces
{
    public interface IDataSource
    {
        Task AddContactAsync(Contact contact);
        Task<List<Contact>> GetAllContactsAsync();
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(int id);
    }
}
