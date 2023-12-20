using ContactLibraryMaui.MVVM.ViewModels;
using ContactLibraryMaui.MVVM.Views;
using ContactsLibrary.Interfaces;
using ContactsLibrary.Models;
using ContactsLibrary.Services;



namespace ContactLibraryMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<AddPage>();
            builder.Services.AddSingleton<AddViewModel>();

            builder.Services.AddSingleton<DetailsPage>();
            builder.Services.AddSingleton<DetailsViewModel>();

            builder.Services.AddSingleton<EditPage>();
            builder.Services.AddSingleton<EditViewModel>();

            builder.Services.AddSingleton<ListPage>();
            builder.Services.AddSingleton<ListViewModel>();



            builder.Services.AddSingleton<IContactservice, ContactService>();
            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<ICustomer, Customer>();




            return builder.Build();
        }
    }
}
