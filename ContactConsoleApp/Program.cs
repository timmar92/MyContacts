using ContactConsoleApp.Interfaces;
using ContactConsoleApp.Services;
using ContactsLibrary.Interfaces;
using ContactsLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IMenuService, MenuService>();
    services.AddSingleton<IContactservice, ContactService>();
    services.AddSingleton<IFileService, FileService>();


}).Build();

builder.Start();
Console.Clear();

StartApp(builder);

static void StartApp(IHost builder)
{
    var menuService = builder.Services.GetService<IMenuService>();
    menuService!.ShowMainMenu();
}