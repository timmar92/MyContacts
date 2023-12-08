using ContactsLibrary.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ContactsLibrary.Services;

/// <summary>
/// ContactService class
/// </summary>
public class ContactService : IContactservice
{
    private List<IContact> _contactList = new List<IContact>();
    private readonly IFileService _fileService;
    private readonly string _filePath = @"c:\WIN23\files\mycontacts.json";

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    /// <summary>
    /// adds a contact to the list and saves it to a file by calling the FileService class and the SaveContactListToFile method
    /// </summary>
    /// <param name="contact">takes a string and converts it to a json file</param>
    /// <returns>returns true if success, returns false if failed</returns>
    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contactList.Any(x => x.Email == contact.Email))
            {
                _contactList.Add(contact);

                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContactListToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - AddContactToList::" + ex.Message); }
        return false;


    }

    /// <summary>
    /// gets all contacts from the list and returns it as an IEnumerable list
    /// </summary>
    /// <returns>returns the list if the list is not null, returns null if it is null</returns>
    public IEnumerable<IContact> GetAllContactsFromList()
    {
        try
        {
            var content = _fileService.GetContactListFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<List<IContact>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contactList;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - GetContactsFromList::" + ex.Message); }
        return null!;
    }

    /// <summary>
    /// gets a single contact from the list by email address 
    /// </summary>
    /// <param name="email">uses the string email</param>
    /// <returns>returns a single contact if the contact exists, returns null if else</returns>
    public IContact GetSingleContact(string email)
    {
        try
        {
            GetAllContactsFromList();
            var contact = _contactList.FirstOrDefault(x => x.Email == email);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - GetSingleContact::" + ex.Message); }
        return null!;
    }

    /// <summary>
    /// removes a contact from the list by email address
    /// </summary>
    /// <param name="email">uses the string email</param>
    /// <returns>removes a single contact by email if contact exists, else returns false</returns>
    public bool RemoveContactFromList(string email)
    {
        try
        {
            GetAllContactsFromList();
            var contactRemove = _contactList.FirstOrDefault(x => x.Email == email);
            if (contactRemove != null)
            {
                _contactList.Remove(contactRemove);
                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContactListToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - RemoveContactFromList::" + ex.Message); }
        return false;
    }

    /// <summary>
    /// updates a contact from the list by email address
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public bool UpdateContactFromList(IContact contact)
    {
        try
        {
            GetAllContactsFromList();
            var contactUpdate = _contactList.FirstOrDefault(x => x.Email == contact.Email);
            if (contactUpdate != null)
            {
                _contactList.Remove(contactUpdate);
                _contactList.Add(contact);
                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContactListToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - UpdateContactFromList::" + ex.Message); }
        return false;
    }
}
