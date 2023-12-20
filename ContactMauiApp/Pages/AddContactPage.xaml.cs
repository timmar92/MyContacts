using ContactMauiApp.ViewModels;

namespace ContactMauiApp.Pages;

public partial class AddContactPage : ContentPage
{
	public AddContactPage(AddContactViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}