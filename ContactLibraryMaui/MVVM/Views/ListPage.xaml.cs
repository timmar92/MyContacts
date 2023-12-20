using ContactLibraryMaui.MVVM.ViewModels;

namespace ContactLibraryMaui.MVVM.Views;

public partial class ListPage : ContentPage
{
    public ListPage(ListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}