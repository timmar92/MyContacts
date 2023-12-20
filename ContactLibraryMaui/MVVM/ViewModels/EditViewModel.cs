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


    /// <summary>
    /// creates a Contact object and asigns it to ICustomer
    /// </summary>
    /// <param name="query"></param>
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Contact = (query["customer"] as ICustomer)!;
    }

    /// <summary>
    /// deletes the selected contact from the list and replaces it with the updated contact and navigates back to the ListPage
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    private async Task Update()
    {
        if (Contact != null && !string.IsNullOrWhiteSpace(Contact.Email))
        {
            _contactService.UpdateContactFromList(Contact);
            await Shell.Current.GoToAsync("//ListPage");
        }
    }

    /// <summary>
    /// navigates back to the ListPage
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    private async Task NavigateToList()
    {
        await Shell.Current.GoToAsync("//ListPage");
    }
}
