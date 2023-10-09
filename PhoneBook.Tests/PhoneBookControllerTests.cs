using Microsoft.AspNetCore.Mvc;
using Moq;
using PhoneBook.Controllers;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Tests
{
    public class PhoneBookControllerTests
    {
        private readonly Mock<IPhoneBookService> _phoneBookServiceMock;
        private readonly PhoneBookController _controller;

        public PhoneBookControllerTests()
        {
            _phoneBookServiceMock = new Mock<IPhoneBookService>();
            _controller = new PhoneBookController(_phoneBookServiceMock.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        #region GetPhoneBookEntries

        [Test]
        public async Task GetPhoneBookEntries_CallsPhoneBookService()
        {
            await _controller.GetPhoneBookEntries();

            _phoneBookServiceMock.Verify(s => s.ListAsync(), Times.Once);
        }

        [Test]
        public async Task GetPhoneBookEntries_ReturnsPhoneBookEntriesList()
        {
            var expectedRecordsList = new List<PhoneBookEntry>
            {
                new PhoneBookEntry{ Firstname = "Test", Surname = "TestSurname", PhoneNumber = "09876543", PhoneBookEntryId = 1 }
            };
            _phoneBookServiceMock.Setup(s => s.ListAsync()).ReturnsAsync(expectedRecordsList);


            var result = await _controller.GetPhoneBookEntries();

            Assert.That(result, Is.EqualTo(expectedRecordsList));
        }

        #endregion

        #region EditPhoneBookEntry

        [Test]
        public async Task EditPhoneBookEntry_InvalidRequestParameters_ReturnsBadRequestResult()
        {
            var response = await _controller.EditPhoneBookEntry(3, new PhoneBookEntry { PhoneBookEntryId = 1 });

            Assert.IsAssignableFrom<BadRequestResult>(response.Result);
        }

        [Test]
        public async Task EditPhoneBookEntry_InvalidRequestParameters_DoesNotCallPhoneBookService()
        {
            var phoneBookEntry = new PhoneBookEntry { PhoneBookEntryId = 1 };
            await _controller.EditPhoneBookEntry(3, phoneBookEntry);

            _phoneBookServiceMock.Verify(s => s.UpdateAsync(phoneBookEntry), Times.Never);
        }

        [Test]
        public async Task EditPhoneBookEntry_ValidRequestParameters_CallsPhoneBookService()
        {
            var phoneBookEntry = new PhoneBookEntry { PhoneBookEntryId = 1 };
            await _controller.EditPhoneBookEntry(1, phoneBookEntry);

            _phoneBookServiceMock.Verify(s => s.UpdateAsync(phoneBookEntry), Times.Once);
        }

        [Test]
        public async Task EditPhoneBookEntry_ExceptionDuringUpdate_ReturnsNotFoundResult()
        {
            var phoneBookEntry = new PhoneBookEntry { PhoneBookEntryId = 1 };
            _phoneBookServiceMock
                .Setup(s => s.UpdateAsync(phoneBookEntry))
                .ThrowsAsync(new Exception());

            var response = await _controller.EditPhoneBookEntry(1, phoneBookEntry);

            Assert.IsAssignableFrom<NotFoundResult>(response.Result);
        }

        [Test]
        public async Task EditPhoneBookEntry_ValidRequest_ReturnsNoContentResult()
        {
            var phoneBookEntry = new PhoneBookEntry { PhoneBookEntryId = 1 };

            var response = await _controller.EditPhoneBookEntry(1, phoneBookEntry);

            Assert.IsAssignableFrom<NoContentResult>(response.Result);
        }

        #endregion
    }
}