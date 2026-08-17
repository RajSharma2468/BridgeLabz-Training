using Microsoft.EntityFrameworkCore;
using FundooNotes.Model.Entities;

namespace FundooNotes.Repository.Data
{
    // Manages database connection and entity sets
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}