using FundooNotes.Model.Entities;

namespace FundooNotes.Repository
{
    // Defines note data operations
    public interface INoteRepository
    {
        List<Note> GetAll();
        Note GetById(int id);
        void Add(Note note);
        void Delete(int id);
    }
}