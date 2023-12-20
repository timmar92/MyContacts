using ContactMauiApp.ViewModels;

namespace ContactMauiApp.Pages;

public partial class EditContactPage : ContentPage
{
    public EditContactPage(EditContactViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}