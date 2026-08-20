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
            note.UserId = dto.UserId;
            note.CreatedAt = DateTime.UtcNow;
            note.IsTrashed = false;
            note.IsArchived = false;

            _repository.Add(note);
        }

        // Returns all notes mapped to response DTOs
        public List<NoteResponseDTO> GetAllNotes()
        {
            var notes = _repository.GetAll();
            return MapToDtoList(notes);
        }

        // Returns single note by id
        public NoteResponseDTO GetNoteById(int id)
        {
            var note = _repository.GetById(id);
            if (note == null)
                throw new UserNotFoundException($"Note with id {id} not found.");

            return MapToDto(note);
        }

        // Deletes note permanently after existence check
        public void DeleteNote(int id)
        {
            var note = _repository.GetById(id);
            if (note == null)
                throw new UserNotFoundException($"Note with id {id} not found.");

            _repository.Delete(id);
        }

        // Toggles the trashed flag on a note
        public void TrashNote(int id)
        {
            var note = _repository.GetById(id);
            if (note == null)
                throw new UserNotFoundException($"Note with id {id} not found.");

            note.IsTrashed = !note.IsTrashed;
            _repository.Update(note);
        }

        // Toggles the archived flag on a note
        public void ArchiveNote(int id)
        {
            var note = _repository.GetById(id);
            if (note == null)
                throw new UserNotFoundException($"Note with id {id} not found.");

            note.IsArchived = !note.IsArchived;
            _repository.Update(note);
        }

        // Filters notes by status: active, trash, or archive
        public List<NoteResponseDTO> FilterNotes(string status)
        {
            bool? isTrashed = null;
            bool? isArchived = null;

            if (status == "trash")
            {
                isTrashed = true;
            }
            else if (status == "archive")
            {
                isArchived = true;
            }
            else if (status == "active")
            {
                isTrashed = false;
                isArchived = false;
            }
            else
            {
                throw new ValidationException("Invalid status. Use active, trash, or archive.");
            }

            var notes = _repository.GetFiltered(isTrashed, isArchived);
            return MapToDtoList(notes);
        }

        // Sorts notes by title or createdAt
        public List<NoteResponseDTO> SortNotes(string sortBy, string order)
        {
            var notes = _repository.GetSorted(sortBy, order);
            return MapToDtoList(notes);
        }

        // Converts a single entity to response DTO
        private NoteResponseDTO MapToDto(Note note)
        {
            NoteResponseDTO dto = new NoteResponseDTO();
            dto.NoteId = note.NoteId;
            dto.Title = note.Title;
            dto.CreatedAt = note.CreatedAt;
            dto.IsTrashed = note.IsTrashed;
            dto.IsArchived = note.IsArchived;
            return dto;
        }

        // Converts a list of entities to response DTOs
        private List<NoteResponseDTO> MapToDtoList(List<Note> notes)
        {
            List<NoteResponseDTO> result = new List<NoteResponseDTO>();
            foreach (var note in notes)
            {
                result.Add(MapToDto(note));
            }
            return result;
        }
    }
}