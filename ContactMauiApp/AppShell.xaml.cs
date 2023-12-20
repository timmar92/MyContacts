using ContactMauiApp.Pages;

namespace ContactMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(ShowAllContactsPage), typeof(ShowAllContactsPage));
            Routing.RegisterRoute(nameof(WelcomePage), typeof(WelcomePage));
        }
    }
}
