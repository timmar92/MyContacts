using ContactLibraryMaui.MVVM.Views;

namespace ContactLibraryMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ListPage), typeof(ListPage));
            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
            Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
        }
    }
}
