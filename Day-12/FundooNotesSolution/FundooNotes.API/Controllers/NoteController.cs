using Microsoft.AspNetCore.Mvc;
using FundooNotes.Business;
using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.Exceptions;

namespace FundooNotes.API.Controllers
{
    // Handles HTTP requests related to Notes.
    [ApiController]
    [Route("api/note")]
    public class NoteController : ControllerBase
    {
        private readonly INoteBusiness _business;
        private readonly IEmailService _emailService;

        // Both Business layer and Email service
        // are injected through constructor.
        public NoteController(
            INoteBusiness business,
            IEmailService emailService)
        {
            _business = business;
            _emailService = emailService;
        }

        // GET: api/note
        // Returns all notes.
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(
                _business.GetAllNotes());
        }

        // GET: api/note/1
        // Returns one note.
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(
                    _business.GetNoteById(id));
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/note
        // Creates a new note.
        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateNoteRequestDTO dto)
        {
            try
            {
                _business.CreateNote(dto);

                return Ok(
                    "Note created successfully.");
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/note/1
        // Permanently deletes a note.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _business.DeleteNote(id);

                return Ok(
                    "Note deleted successfully.");
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/note/1/trash
        // Moves note to or removes note from trash.
        [HttpPut("{id}/trash")]
        public IActionResult Trash(int id)
        {
            try
            {
                _business.TrashNote(id);

                return Ok(
                    "Trash status updated.");
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/note/1/archive
        // Archives or unarchives note.
        [HttpPut("{id}/archive")]
        public IActionResult Archive(int id)
        {
            try
            {
                _business.ArchiveNote(id);

                return Ok(
                    "Archive status updated.");
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/note/1/pin
        // Pins or unpins a note.
        [HttpPut("{id}/pin")]
        public IActionResult Pin(int id)
        {
            try
            {
                _business.PinNote(id);

                return Ok(
                    "Pin status updated.");
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/note/1/label
        // Updates label of a note.
        [HttpPut("{id}/label")]
        public IActionResult UpdateLabel(
            int id,
            [FromBody] UpdateLabelRequestDTO dto)
        {
            try
            {
                // Send label to business layer.
                _business.UpdateLabel(
                    id,
                    dto.Label);

                return Ok(
                    new
                    {
                        Success = true,
                        Message =
                            "Note label updated successfully.",
                        Data = (string)null
                    });
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(
                    new
                    {
                        Success = false,
                        Message = ex.Message,
                        Data = (string)null
                    });
            }
        }

        // GET: api/note/filter?status=trash
        // Filters notes.
        [HttpGet("filter")]
        public IActionResult Filter(
            [FromQuery] string status)
        {
            return Ok(
                _business.FilterNotes(status));
        }

        // GET: api/note/sort?sortBy=title&order=asc
        // Sorts notes.
        [HttpGet("sort")]
        public IActionResult Sort(
            [FromQuery] string sortBy,
            [FromQuery] string order)
        {
            return Ok(
                _business.SortNotes(
                    sortBy,
                    order));
        }


        // POST: api/note/1/send-reminder?email=test@gmail.com
        // Manually triggers reminder email.
        [HttpPost("{id}/send-reminder")]
        public async Task<IActionResult> SendReminder(
            int id,
            [FromQuery] string email)
        {
            // Get note first.
            var note =
                _business.GetNoteById(id);

            // Send email using SMTP service.
            await _emailService.SendReminderEmail(
                email,
                note.Title);

            return Ok(
                "Reminder email sent successfully.");
        }

    }

}