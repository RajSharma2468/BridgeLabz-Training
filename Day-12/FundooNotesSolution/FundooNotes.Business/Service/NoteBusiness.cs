using Microsoft.Extensions.Caching.Memory;
using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.DTOs.Response;
using FundooNotes.Model.Entities;
using FundooNotes.Model.Exceptions;
using FundooNotes.Repository;

namespace FundooNotes.Business
{
    // Business layer contains validation and application logic.
    public class NoteBusiness : INoteBusiness
    {
        private readonly INoteRepository _repository;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "AllNotes";

        // Repository and cache are injected through constructor.
        public NoteBusiness(
            INoteRepository repository,
            IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        // Creates a new note.
        public void CreateNote(
            CreateNoteRequestDTO dto)
        {
            // Validate title.
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                throw new ValidationException(
                    "Title cannot be empty.");
            }

            // Create entity object.
            Note note = new Note();

            note.Title = dto.Title;
            note.UserId = dto.UserId;
            note.CreatedAt = DateTime.Now;
            note.IsTrashed = false;
            note.IsArchived = false;
            note.IsPinned = false;
            note.Label = null;
            note.ReminderDateTime = null;

            // Save note through repository.
            _repository.Add(note);

            // Clear cache since data changed.
            InvalidateCache();
        }

        // Returns all notes, using cache when available.
        public List<NoteResponseDTO> GetAllNotes()
        {
            // Check cache first before hitting database.
            if (_cache.TryGetValue(CacheKey, out List<NoteResponseDTO> cachedNotes))
            {
                return cachedNotes;
            }

            var notes = _repository.GetAll();

            var result = notes
                .Select(MapToDto)
                .ToList();

            // Store result in cache for 5 minutes.
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

            _cache.Set(CacheKey, result, cacheOptions);

            return result;
        }

        // Returns a single note by ID.
        public NoteResponseDTO GetNoteById(int id)
        {
            var note = _repository.GetById(id);

            if (note == null)
            {
                throw new UserNotFoundException(
                    $"Note with id {id} not found.");
            }

            return MapToDto(note);
        }

        // Permanently deletes note.
        public void DeleteNote(int id)
        {
            var note = _repository.GetById(id);

            if (note == null)
            {
                throw new UserNotFoundException(
                    $"Note with id {id} not found.");
            }

            _repository.Delete(id);

            // Clear cache since data changed.
            InvalidateCache();
        }

        // Moves note to trash.
        public void TrashNote(int id)
        {
            var note = _repository.GetById(id);

            if (note == null)
            {
                throw new UserNotFoundException(
                    $"Note with id {id} not found.");
            }

            // Toggle trash status.
            note.IsTrashed = !note.IsTrashed;

            _repository.Update(note);

            // Clear cache since data changed.
            InvalidateCache();
        }

        // Archives a note.
        public void ArchiveNote(int id)
        {
            var note = _repository.GetById(id);

            if (note == null)
            {
                throw new UserNotFoundException(
                    $"Note with id {id} not found.");
            }

            // Toggle archive status.
            note.IsArchived = !note.IsArchived;

            _repository.Update(note);

            // Clear cache since data changed.
            InvalidateCache();
        }

        // Toggles the pinned flag on a note.
        public void PinNote(int id)
        {
            var note = _repository.GetById(id);

            if (note == null)
            {
                throw new UserNotFoundException(
                    $"Note with id {id} not found.");
            }

            // Toggle pin status.
            note.IsPinned = !note.IsPinned;

            _repository.Update(note);

            // Clear cache since data changed.
            InvalidateCache();
        }

        // Filters notes based on status.
        public List<NoteResponseDTO> FilterNotes(
            string status)
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
                throw new ValidationException(
                    "Invalid status. Use active, trash, or archive.");
            }

            var notes =
                _repository.GetFiltered(
                    isTrashed,
                    isArchived);

            return notes
                .Select(MapToDto)
                .ToList();
        }

        // Sorts notes.
        public List<NoteResponseDTO> SortNotes(
            string sortBy,
            string order)
        {
            var notes =
                _repository.GetSorted(
                    sortBy,
                    order);

            return notes
                .Select(MapToDto)
                .ToList();
        }

        // Updates label of a note.
        public void UpdateLabel(
            int id,
            string label)
        {
            // Find note first.
            var note = _repository.GetById(id);

            // If note doesn't exist, throw exception.
            if (note == null)
            {
                throw new UserNotFoundException(
                    $"Note with id {id} not found.");
            }

            // Update label.
            note.Label = label;

            // Save updated note.
            _repository.Update(note);

            // Clear cache since data changed.
            InvalidateCache();
        }

        // Removes cached data so next GetAllNotes fetches fresh data.
        private void InvalidateCache()
        {
            _cache.Remove(CacheKey);
        }

        // Converts Entity into Response DTO.
        private NoteResponseDTO MapToDto(
            Note note)
        {
            NoteResponseDTO dto =
                new NoteResponseDTO();

            dto.NoteId = note.NoteId;
            dto.Title = note.Title;
            dto.CreatedAt = note.CreatedAt;
            dto.IsTrashed = note.IsTrashed;
            dto.IsArchived = note.IsArchived;
            dto.Label = note.Label;
            dto.ReminderDateTime = note.ReminderDateTime;
            dto.IsPinned = note.IsPinned;

            return dto;
        }
    }
}