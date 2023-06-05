using System;
using System.Collections.Generic;

namespace PhoneBook.Models;

public partial class PhoneBookEntry
{
    public long PhoneBookEntryId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;
}
