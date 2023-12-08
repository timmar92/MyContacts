using ContactConsoleApp.Interfaces;
using ContactConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddSingleton<IMenuService, MenuService>();

}).Build();

builder.Start();
Console.Clear();

StartApp(builder);

static void StartApp(IHost builder)
{
    var menuService = builder.Services.GetService<IMenuService>();
    menuService!.ShowMainMenu();
}