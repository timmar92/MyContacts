using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsLibrary.Interfaces;
using ContactsLibrary.Models;

namespace ContactLibraryMaui.MVVM.ViewModels;

public partial class EditViewModel : ObservableObject, IQueryAttributable
{
    private readonly IContactservice _contactService;

    public EditViewModel(IContactservice contactService)
    {
        _contactService = contactService;
    }


    [ObservableProperty]
    private ICustomer _contact = new Customer();



    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Contact = (query["customer"] as ICustomer)!;
    }


    [RelayCommand]
    private async Task Update()
    {
        if (Contact != null && !string.IsNullOrWhiteSpace(Contact.Email))
        {
            _contactService.UpdateContactFromList(Contact);
            await Shell.Current.GoToAsync("//ListPage");
        }
    }

    [RelayCommand]
    private async Task NavigateToList()
    {
        await Shell.Current.GoToAsync("//ListPage");
    }
}
