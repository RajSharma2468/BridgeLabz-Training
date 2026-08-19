using FundooNotes.Model.Entities;
using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.DTOs.Response;
using FundooNotes.Model.Exceptions;
using FundooNotes.Repository;

namespace FundooNotes.Business
{
    // Handles note business logic
    public class NoteBusiness : INoteBusiness
    {
        private readonly INoteRepository _repository;

        public NoteBusiness(INoteRepository repository)
        {
            _repository = repository;
        }

        // Validates and creates a new note
        public void CreateNote(CreateNoteRequestDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
                throw new ValidationException("Title cannot be empty.");

            Note note = new Note();
            note.Title = dto.Title;
            note.Description = dto.Description;
            note.UserId = dto.UserId;
            note.CreatedAt = DateTime.UtcNow;

            _repository.Add(note);
        }

        // Returns all notes mapped to response DTOs
        public List<NoteResponseDTO> GetAllNotes()
        {
            var notes = _repository.GetAll();
            List<NoteResponseDTO> result = new List<NoteResponseDTO>();

            foreach (var note in notes)
            {
                NoteResponseDTO dto = new NoteResponseDTO();
                dto.NoteId = note.NoteId;
                dto.Title = note.Title;
                dto.Description = note.Description;
                dto.CreatedAt = note.CreatedAt;
                result.Add(dto);
            }

            return result;
        }

        // Returns single note by id
        public NoteResponseDTO GetNoteById(int id)
        {
            var note = _repository.GetById(id);
            if (note == null)
                throw new UserNotFoundException($"Note with id {id} not found.");

            NoteResponseDTO dto = new NoteResponseDTO();
            dto.NoteId = note.NoteId;
            dto.Title = note.Title;
            dto.Description = note.Description;
            dto.CreatedAt = note.CreatedAt;

            return dto;
        }

        // Deletes note after existence check
        public void DeleteNote(int id)
        {
            var note = _repository.GetById(id);
            if (note == null)
                throw new UserNotFoundException($"Note with id {id} not found.");

            _repository.Delete(id);
        }
    }
}