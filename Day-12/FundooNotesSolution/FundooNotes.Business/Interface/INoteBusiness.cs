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
    }
}