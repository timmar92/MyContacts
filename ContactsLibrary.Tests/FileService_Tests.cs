using ContactsLibrary.Interfaces;
using ContactsLibrary.Services;

namespace ContactsLibrary.Tests;

public class FileService_Tests
{
    [Fact]
    public void GetContactListFromFile_Should_Get_ContactListFromFile_Then_ReturnTue_If_FilePathExists()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"c:\WIN23\files\test.txt";
        string content = "Hello World!";

        // Act
        bool result = fileService.SaveContactListToFile(filePath, content);

        // Assert
        Assert.True(result);

    }

    [Fact]
    public void SaveContactListToFile_Should_Save_ContactListToFile_Then_ReturnTrue_If_FilePathExists()
    {
        // Arrange
        IFileService fileService = new FileService();
        string filePath = @"c:\WIN23\files\test.txt";
        string content = "Hello World!";

        // Act
        bool result = fileService.SaveContactListToFile(filePath, content);

        // Assert
        Assert.True(result);
    }
}
