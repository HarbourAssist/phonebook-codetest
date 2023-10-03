using Moq;
using PhoneBook.FakeServices;

namespace PhoneBook.Tests
{
    public class PhoneNumberValidatorTests
    {
        [Test]
        public void InvalidNumberReturnsFalse()
        {
            var phoneNumberLookupService = new Mock<IPhoneNumberLookupService>();
            var alertService = new Mock<IAlertService>();
            var phoneNumberValidator = new PhoneNumberValidator(phoneNumberLookupService.Object, alertService.Object);

            var isValid = phoneNumberValidator.IsValid("12345");

            Assert.False(isValid);
        }

        [Test]
        public void InvalidNumberTriggersAlert()
        {
            var phoneNumberLookupService = new Mock<IPhoneNumberLookupService>();
            var alertService = new Mock<IAlertService>();
            var phoneNumberValidator = new PhoneNumberValidator(phoneNumberLookupService.Object, alertService.Object);

            var isValid = phoneNumberValidator.IsValid("12345");

            Assert.False(isValid);
            alertService.Verify(alertService => alertService.SendNotification(), Times.Once());
        }

        [Test]
        public void ValidNumberReturnsTrue()
        {
            var phoneNumberLookupService = new Mock<IPhoneNumberLookupService>();
            phoneNumberLookupService
                .Setup(lookupService => lookupService.Exists(It.IsAny<string>()))
                .Returns(true);
            var alertService = new Mock<IAlertService>();
            var phoneNumberValidator = new PhoneNumberValidator(phoneNumberLookupService.Object, alertService.Object);

            var isValid = phoneNumberValidator.IsValid("12345");

            Assert.True(isValid);
        }
    }
}