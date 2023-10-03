using PhoneBook.Models;
using PhoneBook.Models.Input;
using PhoneBook.Repositories;

namespace PhoneBook.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public PhoneBookService(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public IEnumerable<PhoneBookEntry> GetAll()
        {
            return _phoneBookRepository.GetAll();
        }

        public PhoneBookEntry Add(NewPhoneBookEntry newPhoneBookEntry)
        {
            var phoneBookEntry = new PhoneBookEntry
            {
                Firstname = newPhoneBookEntry.Firstname,
                Surname = newPhoneBookEntry.Surname,
                PhoneNumber = newPhoneBookEntry.PhoneNumber,
            };
            return _phoneBookRepository.Add(phoneBookEntry);
        }

        public PhoneBookEntry Edit(int id, PhoneBookEntry updatedPhoneBookEntry)
        {
            return _phoneBookRepository.Edit(updatedPhoneBookEntry);
        }

        public void Remove(int id)
        {
            var entry = _phoneBookRepository.GetSingle(id);
            _phoneBookRepository.Remove(entry);
        }
    }
}
