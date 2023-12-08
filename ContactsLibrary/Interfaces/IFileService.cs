namespace ContactsLibrary.Interfaces
{
    public interface IFileService
    {
        bool SaveContactListToFile(string filePath, string content);
        string GetContactListFromFile(string filePath);

    }
}
