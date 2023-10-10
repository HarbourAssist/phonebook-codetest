using PhoneBook.Models;

namespace PhoneBook.Repositories
{
    public interface IPhoneBookRepository
    {
        Task CreateAsync(PhoneBookEntry phoneBookEntry);
        Task<IEnumerable<PhoneBookEntry>> ListAsync();
        Task UpdateAsync(PhoneBookEntry phoneBookEntry);
        Task DeleteAsync(long phoneBookEntryId);
    }
}
