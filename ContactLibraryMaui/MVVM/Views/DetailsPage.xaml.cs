using ContactLibraryMaui.MVVM.ViewModels;

namespace ContactLibraryMaui.MVVM.Views;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}