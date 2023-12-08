namespace ContactsLibrary.Interfaces;

/// <summary>
/// Interface for contact service
/// </summary>
public interface IContactservice
{
    bool AddContactToList(IContact contact);
    bool UpdateContactFromList(IContact contact);
    bool RemoveContactFromList(string email);
    IContact GetSingleContact(string email);
    IEnumerable<IContact> GetAllContactsFromList();
}
