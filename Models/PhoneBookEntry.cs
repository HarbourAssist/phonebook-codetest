using System;
using System.Collections.Generic;
using PhoneBook.Repository;

namespace PhoneBook.Models;

public partial class PhoneBookEntry
{

    public long PhoneBookEntryId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;


    private readonly IPhoneBookRepository _phoneBookRepository;

    public PhoneBookEntry()
    {
        //Init the repo
        _phoneBookRepository = RepositoryFactory.InitPhoneBookRepository();
    }

    /// <summary>
    /// Gets a list of all the available phone book entries
    /// </summary>
    /// <returns></returns>
    public async Task<IList<PhoneBookEntry>> GetAllPhoneBookEntries()
    {
        try
        {
            return await _phoneBookRepository.GetAllPhoneBookEntries();
        }
        catch (Exception e)
        {
            //LOG ERROR to LogFile with actual error details and throw custom error to front end
            throw new Exception("Failed to retreive your phonebook entries, please reload the page.");
        }
    }

    /// <summary>
    /// Saves a new phonebook entry
    /// </summary>
    /// <param name="phoneBookEntry"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> SaveNewPhonebookEntry(PhoneBookEntry phoneBookEntry)
    {
        try
        {
            if (phoneBookEntry == null)
            {
                throw new Exception("A phone book entry is required");
            }

            //Validate the phone book entry
            var validationResult = ValidateEntry(phoneBookEntry);

            //Check if the model failed validation
            if (validationResult.Item1 == false)
            {
                //Provide the failure reason back to the UI via the error handling process
                throw new Exception(validationResult.Item2);
            }

            //model validated proceed to save
            var saveResult = await _phoneBookRepository.SaveNewPhonebookEntry(phoneBookEntry);

            if (saveResult)
            {
                //return save result message
                return "Phonebook entry saved successfully";
            }

            //return save failed result message
            return "Phonebook entry save failed";

        }
        catch (Exception e)
        {
            //LOG ERROR to LogFile with actual error details and throw custom error to front end
            throw e;
        }
    }

    /// <summary>
    /// Updates an existing phonebook entry
    /// </summary>
    /// <param name="phoneBookEntry"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> UpdatePhonebookEntry(PhoneBookEntry phoneBookEntry)
    {
        try
        {
            if (phoneBookEntry == null)
            {
                throw new Exception("A phone book entry is required");
            }

            //Validate the phone book entry
            var validationResult = ValidateEntry(phoneBookEntry);

            //Check if the model failed validation
            if (validationResult.Item1 == false)
            {
                //Provide the failure reason back to the UI via the error handling process
                throw new Exception(validationResult.Item2);
            }

            //Get the existing object and update the relevant fields
            var currentPhonebookEntry = await _phoneBookRepository.GetPhonebookEntry(phoneBookEntry.PhoneBookEntryId);

            if (currentPhonebookEntry == null)
            {
                throw new Exception("Phonebook entry provided not found");
            }

            //Update object
            currentPhonebookEntry.Firstname = phoneBookEntry.Firstname;
            currentPhonebookEntry.Surname = phoneBookEntry.Surname;
            currentPhonebookEntry.PhoneNumber = phoneBookEntry.PhoneNumber;

            //Save updated model
            var saveResult = await _phoneBookRepository.UpdatePhonebookEntry(currentPhonebookEntry);

            if (saveResult)
            {
                //return save result message
                return "Phonebook entry updated successfully";
            }

            //return save result
            return "Phonebook entry update failed";
        }
        catch (Exception e)
        {
            //LOG ERROR to LogFile with actual error details and throw custom error to front end
            throw new Exception("Saved failed, please check your entries and try again");
        }
    }

    /// <summary>
    /// Removed an existing phonebook entry
    /// </summary>
    /// <param name="phonebookEntryId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<string> RemovePhonebookEntry(long phonebookEntryId)
    {
        try
        {
            if (phonebookEntryId <= 0)
            {
                throw new Exception("A phone book entry Id is required");
            }

            //Get the existing object and update the relevant fields
            var currentPhonebookEntry = await _phoneBookRepository.GetPhonebookEntry(phonebookEntryId);

            if (currentPhonebookEntry == null)
            {
                throw new Exception("Phonebook entry provided not found");
            }

            //Removed the provided phonebook entry
            await _phoneBookRepository.RemovePhonebookEntry(currentPhonebookEntry);

            //return save result
            return "Phonebook entry removed successfully";
        }
        catch (Exception e)
        {
            //LOG ERROR to LogFile with actual error details and throw custom error to front end
            throw new Exception("Saved failed, please check your entries and try again");
        }
    }

    /// <summary>
    /// Does some entry validation
    /// </summary>
    /// <param name="phoneBookEntry"></param>
    /// <returns></returns>
    private Tuple<bool,string> ValidateEntry(PhoneBookEntry phoneBookEntry)
    {
        try
        {
            if (string.IsNullOrEmpty(phoneBookEntry.Firstname))
            {
                return new Tuple<bool, string>(false, "Fistname is required");
            }

            if (string.IsNullOrEmpty(phoneBookEntry.PhoneNumber))
            {
                return new Tuple<bool, string>(false, "Phone number is required");
            }

            return new Tuple<bool, string>(true, "Valid");
        }
        catch (Exception e)
        {
            throw;
        }
    }
}
