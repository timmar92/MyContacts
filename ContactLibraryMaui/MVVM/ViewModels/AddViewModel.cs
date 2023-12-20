using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsLibrary.Interfaces;
using ContactsLibrary.Models;
using ContactsLibrary.Services;

namespace ContactLibraryMaui.MVVM.ViewModels;

public partial class AddViewModel : ObservableObject
{
    [ObservableProperty]
    private IContactservice _contactService = new ContactService(new FileService());

    [ObservableProperty]
    ICustomer _customer = new Customer();

    public AddViewModel(IContactservice contactService)
    {
        _contactService = contactService;
    }

    [RelayCommand]
    private async Task Add()
    {
        if (Customer != null && !string.IsNullOrWhiteSpace(Customer.Email))
        {
            ContactService.AddContactToList(Customer);
            Customer = new Customer();
            await Shell.Current.GoToAsync("//ListPage");
        }
    }
}
