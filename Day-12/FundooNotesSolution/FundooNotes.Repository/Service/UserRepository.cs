using FundooNotes.Model.Entities;
using FundooNotes.Repository.Data;

namespace FundooNotes.Repository
{
    // Implements user data access using EF Core
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetByResetToken(string token)
        {
            return _context.Users.FirstOrDefault(u => u.ResetToken == token);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}