using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactsLibrary.Interfaces;
using System.Collections.ObjectModel;

namespace ContactLibraryMaui.MVVM.ViewModels;

public partial class ListViewModel : ObservableObject
{
    private readonly IContactservice _contactService;

    [ObservableProperty]
    private ObservableCollection<ICustomer> _mauiList = [];


    public ListViewModel(IContactservice contactService)
    {
        _contactService = contactService;
        _contactService.ContactListUpdated += (sender, e) =>
        {
            MauiList = new ObservableCollection<ICustomer>(_contactService.GetAllContactsFromList());
        };
        GetAllContacts();
    }


    /// <summary>
    /// creates a list of contacts and returns it as an ObservableCollection
    /// </summary>
    public void GetAllContacts()
    {
        MauiList = new ObservableCollection<ICustomer>(_contactService.GetAllContactsFromList());
    }


    /// <summary>
    /// navigates to the AddPage when the button is clicked
    /// </summary>
    /// <returns></returns>
    [RelayCommand]
    private async Task NavigateToAdd()
    {
        await Shell.Current.GoToAsync("AddPage");
    }


    /// <summary>
    /// navigates to the EditPage when the button is clicked and sends the selected contact as a parameter
    /// </summary>
    /// <param name="customer"></param>
    /// <returns></returns>
    [RelayCommand]
    private async Task NavigateToDetails(ICustomer customer)
    {
        var parameters = new ShellNavigationQueryParameters
        {
            { "customer", customer }
        };
        await Shell.Current.GoToAsync("DetailsPage", parameters);
    }
}
