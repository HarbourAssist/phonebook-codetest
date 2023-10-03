using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Models.Input;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly PhoneBookContext _phoneBookContext;

        public PhoneBookController(PhoneBookContext phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        [HttpGet]
        public IEnumerable<PhoneBookEntry> GetAll()
        {
            var phoneBookEntries = _phoneBookContext.PhoneBookEntries;
            return phoneBookEntries;
        }

        [HttpPost]
        public PhoneBookEntry Create(NewPhoneBookEntry newPhoneBookEntry)
        {
            var phoneBookEntry = new PhoneBookEntry
            {
                Firstname = newPhoneBookEntry.Firstname,
                Surname = newPhoneBookEntry.Surname,
                PhoneNumber = newPhoneBookEntry.PhoneNumber,
            };
            _phoneBookContext.PhoneBookEntries.Add(phoneBookEntry);
            _phoneBookContext.SaveChanges();
            
            return phoneBookEntry;
        }

        [HttpPatch("{id}")]
        public PhoneBookEntry Update(int id, PhoneBookEntry updatedPhoneBookEntry)
        {
            var entry = _phoneBookContext.PhoneBookEntries.SingleOrDefault(p => p.PhoneBookEntryId == id);

            if (entry == null)
                throw new ArgumentOutOfRangeException($"Could not find phone book entry {nameof(updatedPhoneBookEntry.PhoneBookEntryId)}={updatedPhoneBookEntry.PhoneBookEntryId}");

            entry.Firstname = updatedPhoneBookEntry.Firstname;
            entry.Surname = updatedPhoneBookEntry.Surname;
            entry.PhoneNumber = updatedPhoneBookEntry.PhoneNumber;
            
            _phoneBookContext.SaveChanges();
            return entry;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entry = _phoneBookContext.PhoneBookEntries.SingleOrDefault(p => p.PhoneBookEntryId == id);

            if (entry == null)
                throw new ArgumentOutOfRangeException($"Could not find phone book entry with {nameof(id)}={id}");

            _phoneBookContext.PhoneBookEntries.Remove(entry);
            _phoneBookContext.SaveChanges();
        }
    }
}