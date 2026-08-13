using Microsoft.EntityFrameworkCore;
using AddressBook.Model.Entities;

namespace AddressBook.Repository.Data
{
    // Manages database connection and entity sets
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AddressEntry> AddressBookEntries { get; set; }
    }
}