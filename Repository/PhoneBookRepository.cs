using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.Repository
{
    public interface IPhoneBookRepository
    {
        /// <summary>
        /// Gets a list of all the available phone book entries
        /// </summary>
        /// <returns></returns>
        Task<IList<PhoneBookEntry>> GetAllPhoneBookEntries();

        /// <summary>
        /// Saves a new phonebook entry
        /// </summary>
        /// <param name="phoneBookEntry"></param>
        /// <returns></returns>
        Task<bool> SaveNewPhonebookEntry(PhoneBookEntry phoneBookEntry);

        /// <summary>
        /// Updates an existing phonebook entry
        /// </summary>
        /// <param name="phoneBookEntry"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<bool> UpdatePhonebookEntry(PhoneBookEntry phoneBookEntry);

        /// <summary>
        /// Remove an existing phonebook entry
        /// </summary>
        /// <param name="phoneBookEntry"></param>
        /// <returns></returns>
        Task<bool> RemovePhonebookEntry(PhoneBookEntry phoneBookEntry);

        /// <summary>
        /// Gets a phonebook entry by ID
        /// </summary>
        /// <param name="phonebookEntryId"></param>
        /// <returns></returns>
        Task<PhoneBookEntry?> GetPhonebookEntry(long phonebookEntryId);
    }

    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookContext _context;

        public PhoneBookRepository()
        {
            //Init the DB context
            _context = RepositoryFactory.InitPhoneBookContext();
        }

        public async Task<IList<PhoneBookEntry>> GetAllPhoneBookEntries()
        {
            try
            {
                return await _context.PhoneBookEntries.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> SaveNewPhonebookEntry(PhoneBookEntry phoneBookEntry)
        {
            try
            {
                var result = _context.PhoneBookEntries.Add(phoneBookEntry);
                await _context.SaveChangesAsync();

                //check if save was successfult
                return result.Entity.PhoneBookEntryId > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdatePhonebookEntry(PhoneBookEntry phoneBookEntry)
        {
            try
            {
                _context.PhoneBookEntries.Update(phoneBookEntry);
                var result = await _context.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> RemovePhonebookEntry(PhoneBookEntry phoneBookEntry)
        {
            try
            {
                _context.PhoneBookEntries.Remove(phoneBookEntry);
                var result = await _context.SaveChangesAsync();

                return result > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PhoneBookEntry?> GetPhonebookEntry(long phonebookEntryId)
        {
            try
            {
                return await _context.PhoneBookEntries.FirstOrDefaultAsync(c => c.PhoneBookEntryId == phonebookEntryId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
