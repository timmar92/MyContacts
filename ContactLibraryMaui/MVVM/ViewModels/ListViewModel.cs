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

    public void GetAllContacts()
    {
        MauiList = new ObservableCollection<ICustomer>(_contactService.GetAllContactsFromList());
    }

    [RelayCommand]
    private async Task NavigateToAdd()
    {
        await Shell.Current.GoToAsync("AddPage");
    }

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
