using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        // GET: phonebook
        [HttpGet("list")]
        public async Task<IEnumerable<PhoneBookEntry>> GetPhoneBookEntries()
        {
            var list = await _phoneBookService.ListAsync();
            return list;
        }

        // POST: phonebook
        [HttpPost]
        public async Task<ActionResult<PhoneBookEntry>> CreatePhoneBookEntry(PhoneBookEntry entry)
        {
            await _phoneBookService.CreateAsync(entry);
            return CreatedAtAction(nameof(GetPhoneBookEntries), entry);
        }

        // PUT: phonebook/{entryId}
        [HttpPut("{entryId}")]
        public async Task<ActionResult<PhoneBookEntry>> EditPhoneBookEntry(long entryId, PhoneBookEntry entry)
        {
            if (entryId != entry.PhoneBookEntryId)
            {
                return BadRequest();
            }

            try
            {
                await _phoneBookService.UpdateAsync(entry);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: phonebook/{entryId}
        [HttpDelete("{entryId}")]
        public async Task<ActionResult> DeletePhoneBookEntry(long entryId)
        {
            try
            {
                await _phoneBookService.DeleteAsync(entryId);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}