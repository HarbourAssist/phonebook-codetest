using PhoneBook.Models;
using PhoneBook.Models.Input;
using PhoneBook.Repositories;

namespace PhoneBook.Integration.Tests
{
    internal class PhoneBookRepositoryFake : IPhoneBookRepository
    {
        private readonly HashSet<PhoneBookEntry> _phoneBookEntries = new() {
            new PhoneBookEntry{ PhoneBookEntryId = 1, Firstname = "Fake", Surname = "Name", PhoneNumber = "12345678910"},
            new PhoneBookEntry{ PhoneBookEntryId = 2, Firstname = "Ian", Surname = "Poster", PhoneNumber = "98765432101"},
        };

        public PhoneBookEntry Add(PhoneBookEntry phoneBookEntry)
        {
            _phoneBookEntries.Add(phoneBookEntry);
            return phoneBookEntry;
        }

        public PhoneBookEntry Edit(PhoneBookEntry updatedPhoneBookEntry)
        {
            var originalPhoneBookEntry = _phoneBookEntries.Single(p => p.PhoneBookEntryId == updatedPhoneBookEntry.PhoneBookEntryId);

            originalPhoneBookEntry.Firstname = updatedPhoneBookEntry.Firstname;
            originalPhoneBookEntry.Surname = updatedPhoneBookEntry.Surname;
            originalPhoneBookEntry.PhoneNumber = updatedPhoneBookEntry.PhoneNumber;

            return originalPhoneBookEntry;
        }

        public IEnumerable<PhoneBookEntry> GetAll()
        {
            return _phoneBookEntries;
        }

        public PhoneBookEntry GetSingle(long phoneBookEntryId)
        {
            return _phoneBookEntries.Single(entry => entry.PhoneBookEntryId == phoneBookEntryId);
        }

        public void Remove(PhoneBookEntry phoneBookEntry)
        {
            _phoneBookEntries.Remove(phoneBookEntry);
        }
    }
}
