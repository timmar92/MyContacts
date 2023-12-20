using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactMauiApp.Pages;
using ContactsLibrary.Interfaces;
using ContactsLibrary.Models;
using ContactsLibrary.Services;

namespace ContactMauiApp.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    [ObservableProperty]
    private IContactservice _contactService = new ContactService(new FileService());

    [ObservableProperty]
    ICustomer _contact = new Customer();


    public AddContactViewModel(IContactservice contactService)
    {
        _contactService = contactService;
    }


    [RelayCommand]
    public void AddContact()
    {
        if (Contact != null && !string.IsNullOrWhiteSpace(Contact.Email))
        {
            ContactService.AddContactToList(Contact);
            Contact = new Customer();
        }

    }

    [RelayCommand]
    private async Task NavigateToContactsPage()
    {
        await Shell.Current.GoToAsync("ShowAllContactsPage");
    }

    //[RelayCommand]
    //private async Task BackToMainPage()
    //{
    //    await Shell.Current.GoToAsync($"../{nameof(WelcomePage)}");
    //}


}
