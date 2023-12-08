using ContactsLibrary.Interfaces;
using System.Diagnostics;

namespace ContactsLibrary.Services;

public class FileService : IFileService
{
    /// <summary>
    /// gets the contact list from a file
    /// </summary>
    /// <param name="filePath"> enter the filepath with extension (eg. c:\WIN23\files.myfile.json) </param>
    /// <returns>returns the list, else returns null</returns>
    public string GetContactListFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);
                return File.ReadAllText(filePath);
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
    /// <summary>
    /// saves the contact list to a file
    /// </summary>
    /// <param name="filePath">enter the filepath with extension (eg. c:\WIN23\files.myfile.json)</param>
    /// <param name="content">enter your content as a string</param>
    /// <returns>returns true if saved, else false if failed</returns>
    public bool SaveContactListToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

}
