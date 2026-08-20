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

        // Deletes a note permanently
        public void Delete(int id)
        {
            var note = _context.Notes.Find(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
                _context.SaveChanges();
            }
        }

        // Updates note flags (trash/archive)
        public void Update(Note note)
        {
            _context.Notes.Update(note);
            _context.SaveChanges();
        }

        // Filters notes by trashed/archived status
        public List<Note> GetFiltered(bool? isTrashed, bool? isArchived)
        {
            var query = _context.Notes.AsQueryable();

            if (isTrashed.HasValue)
                query = query.Where(n => n.IsTrashed == isTrashed.Value);

            if (isArchived.HasValue)
                query = query.Where(n => n.IsArchived == isArchived.Value);

            return query.ToList();
        }

        // Returns notes sorted by given field and order
        public List<Note> GetSorted(string sortBy, string order)
        {
            var query = _context.Notes.AsQueryable();

            if (sortBy == "title")
            {
                query = order == "desc" ? query.OrderByDescending(n => n.Title) : query.OrderBy(n => n.Title);
            }
            else
            {
                // Default sort by CreatedAt
                query = order == "desc" ? query.OrderByDescending(n => n.CreatedAt) : query.OrderBy(n => n.CreatedAt);
            }

            return query.ToList();
        }
    }
}