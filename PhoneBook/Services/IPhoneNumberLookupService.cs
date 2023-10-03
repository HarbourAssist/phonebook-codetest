namespace PhoneBook.FakeServices
{
    public interface IPhoneNumberLookupService
    {
        public bool Exists(string phoneNumber);
    }
}