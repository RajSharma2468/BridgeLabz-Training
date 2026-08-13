using Microsoft.AspNetCore.Mvc;
using AddressBook.Model.Entities;
using AddressBook.Model.Exceptions;
using AddressBook.Business;

namespace AddressBook.API.Controllers
{
    // Handles address book HTTP requests
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        // Business service injected here
        private readonly IAddressBusiness _business;

        public AddressController(IAddressBusiness business)
        {
            _business = business;
        }

        // GET api/address
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_business.GetAllEntries());
        }

        // GET api/address/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var entry = _business.GetEntryById(id);
                return Ok(entry);
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/address
        [HttpPost]
        public IActionResult Create([FromBody] AddressEntry entry)
        {
            try
            {
                _business.AddEntry(entry);
                return Ok("Address entry created successfully.");
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/address/1
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AddressEntry entry)
        {
            try
            {
                _business.UpdateEntry(id, entry);
                return Ok("Address entry updated successfully.");
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/address/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _business.DeleteEntry(id);
                return Ok("Address entry deleted successfully.");
            }
            catch (EntryNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}