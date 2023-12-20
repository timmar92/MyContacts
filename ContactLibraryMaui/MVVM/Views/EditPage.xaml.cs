using ContactLibraryMaui.MVVM.ViewModels;

namespace ContactLibraryMaui.MVVM.Views;

public partial class EditPage : ContentPage
{
    public EditPage(EditViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}