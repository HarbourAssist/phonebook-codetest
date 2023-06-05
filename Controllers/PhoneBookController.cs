using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneBookController : ControllerBase
    {
        private readonly PhoneBookEntry _phonebookEntry;

        public PhoneBookController()
        {
            _phonebookEntry = PhonebookEntryFactory.CreateInstance();
        }

        [ActionName("GetAllEntries")]
        [Route("api/[controller]/GetAllEntries")]
        [HttpGet]
        public async Task<IActionResult> GetAllEntries()
        {
            try
            {
                var result = await _phonebookEntry.GetAllPhoneBookEntries();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //returns the custom error message
            }
        }

        [ActionName("SaveNewPhonebookEntry")]
        [Route("api/[controller]/SaveNewPhonebookEntry")]
        [HttpPost]
        public async Task<IActionResult> SaveNewPhonebookEntry(PhoneBookEntry model)
        {
            try
            {
                var result = await _phonebookEntry.SaveNewPhonebookEntry(model);

                return Ok(result);//return the save message
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //returns the custom error message
            }
        }

        [ActionName("UpdatePhonebookEntry")]
        [Route("api/[controller]/UpdatePhonebookEntry")]
        [HttpPut]
        public async Task<IActionResult> UpdatePhonebookEntry(PhoneBookEntry model)
        {
            try
            {
                var result = await _phonebookEntry.UpdatePhonebookEntry(model);

                return Ok(result);//return the update message
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //returns the custom error message
            }
        }

        [ActionName("RemovePhonebookEntry")]
        [Route("api/[controller]/RemovePhonebookEntry")]
        [HttpDelete]
        public async Task<IActionResult> RemovePhonebookEntry(long id)
        {
            try
            {
                var result = await _phonebookEntry.RemovePhonebookEntry(id);

                return Ok(result);//return the update message
            }
            catch (Exception e)
            {
                return BadRequest(e.Message); //returns the custom error message
            }
        }
    }
}