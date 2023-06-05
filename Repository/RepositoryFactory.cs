using PhoneBook.Models;

namespace PhoneBook.Repository
{
    public static class RepositoryFactory
    {
        public static PhoneBookContext InitPhoneBookContext()
        {
            return new PhoneBookContext();
        }

        public static IPhoneBookRepository InitPhoneBookRepository()
        {
            return new PhoneBookRepository();
        }
    }
}
