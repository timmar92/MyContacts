using ContactsLibrary.Interfaces;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ContactsLibrary.Services;

/// <summary>
/// ContactService class
/// </summary>
public class ContactService : IContactservice
{

    public ObservableCollection<ICustomer> _contactList = [];
    private readonly IFileService _fileService;
    private readonly string _filePath = @"c:\WIN23\files\mycontacts.json";

    public event EventHandler? ContactListUpdated;

    /// <summary>
    /// ContactService constructor
    /// </summary>
    /// <param name="fileService"></param>
    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    /// <summary>
    /// adds a contact to the list and saves it to a file by calling the FileService class and the SaveContactListToFile method
    /// </summary>
    /// <param name="customer">takes a string and converts it to a json file</param>
    /// <returns>returns true if success, returns false if failed</returns>
    public bool AddContactToList(ICustomer customer)
    {
        try
        {
            if (!_contactList.Any(x => x.Email == customer.Email))
            {
                _contactList.Add(customer);


                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContactListToFile(_filePath, json);

                ContactListUpdated?.Invoke(this, EventArgs.Empty);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - AddContactToList::" + ex.Message); }
        return false;


    }

    /// <summary>
    /// gets all contacts from the list and returns it as an IEnumerable list
    /// </summary>
    /// <returns>returns the list if the list is not null, returns null if it is null</returns>
    public IEnumerable<ICustomer> GetAllContactsFromList()
    {
        try
        {
            var content = _fileService.GetContactListFromFile(_filePath);
            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<ObservableCollection<ICustomer>>(content, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All })!;
                return _contactList;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ContactService - GetContactsFromList::" + ex.Message);
            _contactList = new ObservableCollection<ICustomer>();
        }
        return _contactList;
    }

    /// <summary>
    /// gets a single contact from the list by email address 
    /// </summary>
    /// <param name="email">uses the string email</param>
    /// <returns>returns a single contact if the contact exists, returns null if else</returns>
    public ICustomer GetSingleContact(string email)
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

                ContactListUpdated?.Invoke(this, EventArgs.Empty);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - RemoveContactFromList::" + ex.Message); }
        return false;
    }

    /// <summary>
    /// updates a contact from the list by email address
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    public bool UpdateContactFromList(ICustomer customer)
    {
        try
        {
            GetAllContactsFromList();
            var contactIndex = _contactList.IndexOf(_contactList.FirstOrDefault(x => x.Id == customer.Id)!);
            if (contactIndex != -1)
            {
                _contactList[contactIndex] = customer;

                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
                var result = _fileService.SaveContactListToFile(_filePath, json);

                ContactListUpdated?.Invoke(this, EventArgs.Empty);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ContactService - UpdateContactFromList::" + ex.Message); }
        return false;
    }
}
