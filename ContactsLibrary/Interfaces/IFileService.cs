namespace ContactsLibrary.Interfaces
{
    /// <summary>
    /// interface for file service
    /// </summary>
    public interface IFileService
    {
        bool SaveContactListToFile(string filePath, string content);
        string GetContactListFromFile(string filePath);

    }
}
