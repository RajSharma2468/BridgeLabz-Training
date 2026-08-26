using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.DTOs.Response;

namespace FundooNotes.Business
{
    // Defines note business operations contract
    public interface INoteBusiness
    {
        void CreateNote(CreateNoteRequestDTO dto);
        List<NoteResponseDTO> GetAllNotes();
        NoteResponseDTO GetNoteById(int id);
        void DeleteNote(int id);
        void TrashNote(int id);
        void ArchiveNote(int id);
        void UpdateLabel(int id, string label);
        List<NoteResponseDTO> FilterNotes(string status);
        List<NoteResponseDTO> SortNotes(string sortBy, string order);
        // Update note label.
       void PinNote(int id);
    }
}