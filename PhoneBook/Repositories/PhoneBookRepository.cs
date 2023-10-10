using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.Repositories
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookContext _context;

        public PhoneBookRepository(PhoneBookContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PhoneBookEntry phoneBookEntry)
        {
            _context.PhoneBookEntries.Add(Map(phoneBookEntry));
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PhoneBookEntry>> ListAsync()
        {
            return await _context.PhoneBookEntries
                .Select(p => Map(p)).ToListAsync();
        }

        public async Task UpdateAsync(PhoneBookEntry phoneBookEntry)
        {
            var originalPhoneBookEntry = await _context.PhoneBookEntries.FindAsync(phoneBookEntry.PhoneBookEntryId);

            if (originalPhoneBookEntry != null)
            {
                _context.PhoneBookEntries.Attach(originalPhoneBookEntry).CurrentValues.SetValues(Map(phoneBookEntry));
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public async Task DeleteAsync(long phoneBookEntryId)
        {
            var dbPhoneBookEntry = await _context.PhoneBookEntries.FindAsync(phoneBookEntryId);
            if (dbPhoneBookEntry != null)
            {
                _context.PhoneBookEntries.Remove(dbPhoneBookEntry);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        private static PhoneBookEntry Map(DbPhoneBookEntry phoneBookEntry)
        {
            return new PhoneBookEntry
            {
                PhoneBookEntryId = phoneBookEntry.PhoneBookEntryId,
                Firstname = phoneBookEntry.Firstname,
                Surname = phoneBookEntry.Surname,
                PhoneNumber = phoneBookEntry.PhoneNumber
            };
        }

        private static DbPhoneBookEntry Map(PhoneBookEntry phoneBookEntry)
        {
            return new DbPhoneBookEntry
            {
                PhoneBookEntryId = phoneBookEntry.PhoneBookEntryId,
                Firstname = phoneBookEntry.Firstname,
                Surname = phoneBookEntry.Surname,
                PhoneNumber = phoneBookEntry.PhoneNumber
            };
        }
    }
}
