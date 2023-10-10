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

        public Task CreateAsync(PhoneBookEntry phoneBookEntry)
        {
            return _repository.CreateAsync(phoneBookEntry);
        }

        public Task<IEnumerable<PhoneBookEntry>> ListAsync()
        {
            return _repository.ListAsync();
        }

        public Task UpdateAsync(PhoneBookEntry phoneBookEntry)
        {
            return _repository.UpdateAsync(phoneBookEntry);
        }

        public Task DeleteAsync(long phoneBookEntryId)
        {
            return _repository.DeleteAsync(phoneBookEntryId);
        }
    }
}
