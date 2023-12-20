
namespace ContactsLibrary.Interfaces;

/// <summary>
/// Interface for contact service
/// </summary>
public interface IContactservice
{
    event EventHandler? ContactListUpdated;

    bool AddContactToList(ICustomer customer);
    bool UpdateContactFromList(ICustomer customer);
    bool RemoveContactFromList(string email);
    ICustomer GetSingleContact(string email);
    IEnumerable<ICustomer> GetAllContactsFromList();


}
