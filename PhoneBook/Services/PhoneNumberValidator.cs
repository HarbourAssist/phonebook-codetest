namespace PhoneBook.FakeServices
{
    public class PhoneNumberValidator
    {
        private readonly IPhoneNumberLookupService _phoneNumberLookupService;
        private readonly IAlertService _alertService;

        public PhoneNumberValidator(
            IPhoneNumberLookupService phoneNumberLookupService,
            IAlertService alertService)
        {
            _phoneNumberLookupService = phoneNumberLookupService;
            _alertService = alertService;
        }

        public bool IsValid(string phoneNumber)
        {
            if (_phoneNumberLookupService.Exists(phoneNumber))
            {
                return true;
            }

            _alertService.SendNotification();
            return false;
        }
    }
}
