using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PhoneBook.Models;

public partial class PhoneBookEntry
{
    public long PhoneBookEntryId { get; set; }

    [JsonPropertyName("firstName")]
    public string Firstname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}
