using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        [HttpGet]
        public List<PhoneBookEntry> GetAll()
        {
            return new List<PhoneBookEntry> { 
                new PhoneBookEntry { PhoneBookEntryId = 1, Firstname = "Jacca", Surname = "Hooper", PhoneNumber = "01234567890" },
                new PhoneBookEntry { PhoneBookEntryId = 1, Firstname = "Joe", Surname = "Bloggs", PhoneNumber = "98765432101" },
            };
        }
    }
}