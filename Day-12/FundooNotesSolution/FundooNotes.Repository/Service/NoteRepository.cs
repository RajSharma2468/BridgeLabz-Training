using FundooNotes.Model.Entities;
using FundooNotes.Repository.Data;

namespace FundooNotes.Repository
{
    // Implements note data access using EF Core
    public class NoteRepository : INoteRepository
    {
        private readonly AppDbContext _context;

        public NoteRepository(AppDbContext context)
        {
            _context = context;
        }

        // Fetches all notes
        public List<Note> GetAll()
        {
            return _context.Notes.ToList();
        }

        // Fetches single note by id
        public Note GetById(int id)
        {
            return _context.Notes.Find(id);
        }

        // Inserts new note
        public void Add(Note note)
        {
            _context.Notes.Add(note);
            _context.SaveChanges();
        }

        // Deletes a note
        public void Delete(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }
    }
}