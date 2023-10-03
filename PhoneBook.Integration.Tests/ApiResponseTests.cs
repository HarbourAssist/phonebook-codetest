using PhoneBook.Models;
using System.Net;
using System.Net.Http.Json;

namespace PhoneBook.Integration.Tests
{
    public class ApiResponseTests
    {
        [Fact]
        public async void CanGetAllPhoneBookEntriesFromApi()
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
            Assert.Equal(ExpectedPhoneBookApiResponse.GetAll, content);
        }

        [Fact]
        public async void CanCreateNewPhoneBooksEntryFromApi()
        {
            //Arrange
            await using var app = new PhoneBookApplication();
            var client = app.CreateClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/phonebook")
            {
                Content = JsonContent.Create(new { Firstname = "New", Surname = "Entry", PhoneNumber = "11111111111" })
            };

            //Act
            var response = await client.SendAsync(requestMessage);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal(ExpectedPhoneBookApiResponse.Create, content);
        }

        [Fact]
        public async void CanUpdatePhoneBooksEntryFromApi()
        {
            //Arrange
            await using var app = new PhoneBookApplication();
            var client = app.CreateClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Patch, "/api/phonebook/1")
            {
                Content = JsonContent.Create(new { PhoneBookEntryId = 1, Firstname = "Updated", Surname = "Changed", PhoneNumber = "11111111111" })
            };

            //Act
            var response = await client.SendAsync(requestMessage);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
            Assert.Equal(ExpectedPhoneBookApiResponse.Update, content);
        }

        [Fact]
        public async void CanDeletePhoneBooksEntryFromApi()
        {
            //Arrange
            await using var app = new PhoneBookApplication();
            var client = app.CreateClient();
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "/api/phonebook/1");

            //Act
            var response = await client.SendAsync(requestMessage);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var content = await response.Content.ReadAsStringAsync();
        }
    }
}