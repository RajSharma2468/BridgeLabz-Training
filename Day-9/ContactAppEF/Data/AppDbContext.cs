using Microsoft.EntityFrameworkCore;
using ContactAppEF.Model;

namespace ContactAppEF.Data
{
    // Manages database connection and entity sets
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}