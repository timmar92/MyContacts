using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsLibrary.Interfaces;
using System.Collections.ObjectModel;

namespace ContactMauiApp.ViewModels;

public partial class ShowAllContactsViewModel : ObservableObject
{
    private readonly IContactservice _contactService;

    [ObservableProperty]
    private ObservableCollection<ICustomer> _allContactsList = [];

    public ShowAllContactsViewModel(IContactservice contactService)
    {
        _contactService = contactService;
        _contactService.ContactListUpdated += (sender, e) =>
        {
            AllContactsList = new ObservableCollection<ICustomer>(_contactService.GetAllContactsFromList());
        };
        GetAllContacts();

    }





    public void GetAllContacts()
    {
        AllContactsList = new ObservableCollection<ICustomer>(_contactService.GetAllContactsFromList());
    }




    [RelayCommand]
    public void DeleteContact(string email)
    {

        _contactService.RemoveContactFromList(email);
        GetAllContacts();

    }

    [RelayCommand]
    private async Task NavigateToDetails(ICustomer customer)
    {
        var parameters = new ShellNavigationQueryParameters
        {
            { "email", customer.Email }
        };
        await Shell.Current.GoToAsync("ContactDetailsPage", parameters);
    }
}



