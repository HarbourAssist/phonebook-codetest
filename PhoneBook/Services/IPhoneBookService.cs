using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IPhoneBookService
    {
        Task CreateAsync(PhoneBookEntry phoneBookEntry);
        Task<IEnumerable<PhoneBookEntry>> ListAsync();
        Task UpdateAsync(PhoneBookEntry phoneBookEntry);
        Task DeleteAsync(long phoneBookEntryId);
    }
}
