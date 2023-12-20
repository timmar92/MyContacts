using CommunityToolkit.Mvvm.ComponentModel;
using ContactsLibrary.Interfaces;
using ContactsLibrary.Models;

namespace ContactMauiApp.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject, IQueryAttributable
{
    private readonly IContactservice _contactService;

    public ContactDetailsViewModel(IContactservice contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    ICustomer _contact = new Customer();

    public void getContact(string email)
    {
        _contactService.GetSingleContact(email);
        Contact = new Customer();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Contact = (query["email"] as ICustomer)!;
    }
}
