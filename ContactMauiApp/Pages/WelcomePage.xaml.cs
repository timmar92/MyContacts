using ContactMauiApp.ViewModels;

namespace ContactMauiApp.Pages;

public partial class WelcomePage : ContentPage
{
	public WelcomePage(WelcomeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}