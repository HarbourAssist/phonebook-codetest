namespace PhoneBook.Integration.Tests
{
    internal static class ExpectedPhoneBookApiResponse
    {
        public const string GetAll = "[{\"phoneBookEntryId\":1,\"firstname\":\"Fake\",\"surname\":\"Name\",\"phoneNumber\":\"12345678910\"},{\"phoneBookEntryId\":2,\"firstname\":\"Ian\",\"surname\":\"Poster\",\"phoneNumber\":\"98765432101\"}]";
        public const string Create = "{\"phoneBookEntryId\":0,\"firstname\":\"New\",\"surname\":\"Entry\",\"phoneNumber\":\"11111111111\"}";
        public const string Update = "{\"phoneBookEntryId\":1,\"firstname\":\"Updated\",\"surname\":\"Changed\",\"phoneNumber\":\"11111111111\"}";
    }
}
