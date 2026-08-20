using Microsoft.AspNetCore.Mvc;
using FundooNotes.Model.DTOs.Request;
using FundooNotes.Model.DTOs.Response;
using FundooNotes.Model.Exceptions;
using FundooNotes.Business;

namespace FundooNotes.API.Controllers
{
    // Handles note management HTTP requests
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly INoteBusiness _business;

        public NoteController(INoteBusiness business)
        {
            _business = business;
        }

        // POST api/note
        [HttpPost]
        public IActionResult Create([FromBody] CreateNoteRequestDTO dto)
        {
            try
            {
                _business.CreateNote(dto);

                var response = new ResponseDTO<string>
                {
                    Success = true,
                    Message = "Note created successfully.",
                    Data = null
                };
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(response);
            }
        }

        // GET api/note
        [HttpGet]
        public IActionResult GetAll()
        {
            var notes = _business.GetAllNotes();

            var response = new ResponseDTO<List<NoteResponseDTO>>
            {
                Success = true,
                Message = "Notes retrieved successfully.",
                Data = notes
            };
            return Ok(response);
        }

        // GET api/note/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var note = _business.GetNoteById(id);

                var response = new ResponseDTO<NoteResponseDTO>
                {
                    Success = true,
                    Message = "Note retrieved successfully.",
                    Data = note
                };
                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return NotFound(response);
            }
        }

        // DELETE api/note/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _business.DeleteNote(id);

                var response = new ResponseDTO<string>
                {
                    Success = true,
                    Message = "Note deleted successfully.",
                    Data = null
                };
                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return NotFound(response);
            }
        }

        // PUT api/note/1/trash
        [HttpPut("{id}/trash")]
        public IActionResult Trash(int id)
        {
            try
            {
                _business.TrashNote(id);

                var response = new ResponseDTO<string>
                {
                    Success = true,
                    Message = "Note trash status updated.",
                    Data = null
                };
                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return NotFound(response);
            }
        }

        // PUT api/note/1/archive
        [HttpPut("{id}/archive")]
        public IActionResult Archive(int id)
        {
            try
            {
                _business.ArchiveNote(id);

                var response = new ResponseDTO<string>
                {
                    Success = true,
                    Message = "Note archive status updated.",
                    Data = null
                };
                return Ok(response);
            }
            catch (UserNotFoundException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return NotFound(response);
            }
        }

        // GET api/note/filter?status=active
        [HttpGet("filter")]
        public IActionResult Filter([FromQuery] string status)
        {
            try
            {
                var notes = _business.FilterNotes(status);

                var response = new ResponseDTO<List<NoteResponseDTO>>
                {
                    Success = true,
                    Message = $"Notes filtered by status: {status}",
                    Data = notes
                };
                return Ok(response);
            }
            catch (ValidationException ex)
            {
                var response = new ResponseDTO<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                };
                return BadRequest(response);
            }
        }

        // GET api/note/sort?sortBy=title&order=asc
        [HttpGet("sort")]
        public IActionResult Sort([FromQuery] string sortBy, [FromQuery] string order)
        {
            var notes = _business.SortNotes(sortBy, order);

            var response = new ResponseDTO<List<NoteResponseDTO>>
            {
                Success = true,
                Message = $"Notes sorted by {sortBy} ({order})",
                Data = notes
            };
            return Ok(response);
        }
    }
}