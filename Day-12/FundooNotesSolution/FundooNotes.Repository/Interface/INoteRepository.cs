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
        void Update(Note note);
        List<Note> GetFiltered(bool? isTrashed, bool? isArchived);
        List<Note> GetSorted(string sortBy, string order);
    }
}