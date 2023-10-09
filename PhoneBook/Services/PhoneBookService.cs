using PhoneBook.Models;
using PhoneBook.Repositories;

namespace PhoneBook.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookRepository _repository;

        public PhoneBookService(IPhoneBookRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(PhoneBookEntry phoneBookEntry)
        {
            await _repository.CreateAsync(phoneBookEntry);
        }

        public async Task<IEnumerable<PhoneBookEntry>> ListAsync()
        {
            return await _repository.ListAsync();
        }

        public async Task UpdateAsync(PhoneBookEntry phoneBookEntry)
        {
            await _repository.UpdateAsync(phoneBookEntry);
        }

        public async Task DeleteAsync(long phoneBookEntryId)
        {
            await _repository.DeleteAsync(phoneBookEntryId);
        }
    }
}
