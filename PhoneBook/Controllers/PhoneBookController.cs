using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Models.Input;
using PhoneBook.Services;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;

        public PhoneBookController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        [HttpGet]
        public IEnumerable<PhoneBookEntry> GetAll()
        {
            return _phoneBookService.GetAll();
        }

        [HttpPost]
        public PhoneBookEntry Create(NewPhoneBookEntry newPhoneBookEntry)
        {
            return _phoneBookService.Add(newPhoneBookEntry);
        }

        [HttpPatch("{id}")]
        public PhoneBookEntry Update(int id, PhoneBookEntry updatedPhoneBookEntry)
        {
            return _phoneBookService.Edit(id, updatedPhoneBookEntry);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _phoneBookService.Remove(id);
        }
    }
}