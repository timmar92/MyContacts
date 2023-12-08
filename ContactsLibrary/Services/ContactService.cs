using ContactsLibrary.Interfaces;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ContactsLibrary.Services;

public class ContactService : IContactservice
{
    private List<IContact> _contactList = [];
    private readonly IFileService _fileService;
    private readonly string _filePath = @"c:\mycontacts.json";

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public bool AddContactToList(IContact contact)
    {
        try
        {
            if (!_contactList.Any(x => x.Email == contact.Email))
            {
                _contactList.Add(contact);

                string json = JsonConvert.SerializeObject(_contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All});
                var result = _fileService.SaveContactListToFile(_filePath, json);
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;


    }

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
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IContact GetSingleContact(string email)
    {
        try
        {
            GetAllContactsFromList();
            var contact = _contactList.FirstOrDefault(x => x.Email == email);
            return contact ??= null!;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

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
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

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
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
