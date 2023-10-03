using PhoneBook.Models;
using PhoneBook.Models.Input;
using System.Security.Cryptography;

namespace PhoneBook.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookContext _phoneBookContext;

        public PhoneBookRepository(PhoneBookContext phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        public PhoneBookEntry GetSingle(long phoneBookEntryId)
        {
            var phoneBookEntry = _phoneBookContext.PhoneBookEntries.SingleOrDefault(entry => entry.PhoneBookEntryId == phoneBookEntryId);

            if (phoneBookEntry == null)
                throw new ArgumentOutOfRangeException($"Could not find phone book entry {nameof(phoneBookEntryId)}={phoneBookEntryId}");

            return phoneBookEntry;
        }

        public IEnumerable<PhoneBookEntry> GetAll()
        {
            var phoneBookEntries = _phoneBookContext.PhoneBookEntries;
            return phoneBookEntries;
        }

        public PhoneBookEntry Add(PhoneBookEntry phoneBookEntry)
        {
            _phoneBookContext.PhoneBookEntries.Add(phoneBookEntry);
            _phoneBookContext.SaveChanges();

            return phoneBookEntry;
        }

        public PhoneBookEntry Edit(PhoneBookEntry updatedPhoneBookEntry)
        {
            var originalPhoneBookEntry = GetSingle(updatedPhoneBookEntry.PhoneBookEntryId);
            
            originalPhoneBookEntry.Firstname = updatedPhoneBookEntry.Firstname;
            originalPhoneBookEntry.Surname = updatedPhoneBookEntry.Surname;
            originalPhoneBookEntry.PhoneNumber = updatedPhoneBookEntry.PhoneNumber;

            _phoneBookContext.SaveChanges();
            return originalPhoneBookEntry;
        }

        public void Remove(PhoneBookEntry phoneBookEntry)
        {
            var entry = GetSingle(phoneBookEntry.PhoneBookEntryId);
            
            _phoneBookContext.PhoneBookEntries.Remove(entry);
            _phoneBookContext.SaveChanges();
        }
    }
}
