using PhoneBook.Models;

namespace PhoneBook.Repositories
{
    public interface IPhoneBookRepository
    {
        public IEnumerable<PhoneBookEntry> GetAll();
        PhoneBookEntry Add(PhoneBookEntry phoneBookEntry);
        PhoneBookEntry Edit(PhoneBookEntry updatedPhoneBookEntry);
        void Remove(PhoneBookEntry phoneBookEntry);
        PhoneBookEntry GetSingle(long phoneBookEntryId);
    }
}
