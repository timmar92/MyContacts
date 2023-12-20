using ContactLibraryMaui.MVVM.ViewModels;

namespace ContactLibraryMaui.MVVM.Views;

public partial class AddPage : ContentPage
{
    public AddPage(AddViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}