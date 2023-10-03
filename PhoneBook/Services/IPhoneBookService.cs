using PhoneBook.Models;
using PhoneBook.Models.Input;

namespace PhoneBook.Services
{
    public interface IPhoneBookService
    {
        PhoneBookEntry Add(NewPhoneBookEntry newPhoneBookEntry);
        PhoneBookEntry Edit(int id, PhoneBookEntry updatedPhoneBookEntry);
        IEnumerable<PhoneBookEntry> GetAll();
        void Remove(int id);
    }
}