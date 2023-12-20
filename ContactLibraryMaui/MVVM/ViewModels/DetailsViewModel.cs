using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsLibrary.Interfaces;
using ContactsLibrary.Models;

namespace ContactLibraryMaui.MVVM.ViewModels;

public partial class DetailsViewModel : ObservableObject, IQueryAttributable
{
    private readonly IContactservice _contactService;



    [ObservableProperty]
    private ICustomer _contact = new Customer();


    public DetailsViewModel(IContactservice contactService)
    {
        _contactService = contactService;

    }


    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {

        Contact = (query["customer"] as ICustomer)!;

    }



    [RelayCommand]
    private async Task Delete()
    {
        if (Contact != null && !string.IsNullOrWhiteSpace(Contact.Email))
        {
            _contactService.RemoveContactFromList(Contact.Email);
            await Shell.Current.GoToAsync("//ListPage");
        }
    }



    [RelayCommand]
    private async Task NavigateToList()
    {
        await Shell.Current.GoToAsync("//ListPage");
    }



    [RelayCommand]
    private async Task NavigateToEdit()
    {
        var editContact = _contactService.GetSingleContact(Contact.Email);
        var parameters = new ShellNavigationQueryParameters
        {
            { "customer", editContact }
        };
        await Shell.Current.GoToAsync("EditPage", parameters);
    }
}
