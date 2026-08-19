using FundooNotes.Model.Entities;

namespace FundooNotes.Repository
{
    // Defines user data operations
    public interface IUserRepository
    {
        User GetByEmail(string email);
        User GetByResetToken(string token);
        void Add(User user);
        void Update(User user);
    }
}