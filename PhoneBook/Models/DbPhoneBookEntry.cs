using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Models
{
    public class DbPhoneBookEntry
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PhoneBookEntryId { get; set; }

        public string Firstname { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;
    }
}
