using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ContactMauiApp.ViewModels;

public partial class WelcomeViewModel : ObservableObject
{
    [RelayCommand]
    private async Task NavigateToContactsPage()
    {
        await Shell.Current.GoToAsync("ShowAllContactsPage");
    }

    [RelayCommand]
    private async Task NavigateToAddContactPage()
    {
        await Shell.Current.GoToAsync("AddContactPage");
    }


}
