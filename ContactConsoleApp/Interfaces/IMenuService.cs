namespace ContactConsoleApp.Interfaces;

/// <summary>
/// interface for menu service
/// </summary>
internal interface IMenuService
{
    void ShowMainMenu();
    void AddContact();
    void ListAllContacts();
    void ShowSingleContact();
    void DeleteContact();


}