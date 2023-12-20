using ContactMauiApp.ViewModels;

namespace ContactMauiApp.Pages;

public partial class ShowAllContactsPage : ContentPage
{
	public ShowAllContactsPage(ShowAllContactsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;


	}

}