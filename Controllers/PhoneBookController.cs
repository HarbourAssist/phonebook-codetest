using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        public PhoneBookController()
        {
        }

        [HttpGet]
        public List<PhoneBookEntry> Get()
        {
            throw new NotImplementedException();
        }
    }
}