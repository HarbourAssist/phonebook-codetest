using System.Net;

namespace PhoneBook.Integration.Tests
{
    public class ApiResponseTests
    {
        private const string expectedPhoneBookEntriesResponse = "[{\"phoneBookEntryId\":1,\"firstname\":\"Jacca\",\"surname\":\"Hooper\",\"phoneNumber\":\"01234567890\"},{\"phoneBookEntryId\":1,\"firstname\":\"Joe\",\"surname\":\"Bloggs\",\"phoneNumber\":\"98765432101\"}]";

        [Fact]
        public async void CanGetAllPhoneBooksFromApi()
        {
            //Arrange
            await using var app = new PhoneBookApplication();
            var client = app.CreateClient();

            //Act
            var response = await client.GetAsync("/api/phonebook");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal(expectedPhoneBookEntriesResponse, content);
        }
    }
}