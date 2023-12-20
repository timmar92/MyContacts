using ContactMauiApp.ViewModels;

namespace ContactMauiApp.Pages;

public partial class ContactDetailsPage : ContentPage
{
    public ContactDetailsPage(ContactDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}