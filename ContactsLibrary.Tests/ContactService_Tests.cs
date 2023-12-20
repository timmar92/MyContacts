using ContactsLibrary.Interfaces;
using ContactsLibrary.Models;
using ContactsLibrary.Services;
using Moq;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ContactsLibrary.Tests;

public class ContactService_Tests
{

    [Fact]
    public void AddContactToList_Should_Add_ContactToList_Then_ReturnTrue()
    {
        // Arrange
        ICustomer customer = new Customer { Id = Guid.NewGuid(), FirstName = "Tim", LastName = "Mårtensson", PhoneNumber = "235235", Email = "Tim@mail.com", City = "Bromölla", Country = "Sweden" };

        var mockFileService = new Mock<IFileService>();

        IContactservice contactService = new ContactService(mockFileService.Object);

        // Act
        bool result = contactService.AddContactToList(customer);

        // Assert
        Assert.True(result);
    }



    [Fact]
    public void GetAllContactsFromList_Should_Get_AllContactsFromList_Then_ReturnContactList()
    {
        // Arrange
        var contactList = new ObservableCollection<ICustomer> { new Customer { Id = Guid.NewGuid(), FirstName = "Tim", LastName = "Mårtensson", PhoneNumber = "235235", Email = "Tim@mail.com", City = "Bromölla", Country = "Sweden" } };

        string json = JsonConvert.SerializeObject(contactList, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        var mockFileService = new Mock<IFileService>();
        mockFileService.Setup(x => x.GetContactListFromFile(It.IsAny<string>())).Returns(json);

        IContactservice contactService = new ContactService(mockFileService.Object);

        // Act
        IEnumerable<ICustomer> result = contactService.GetAllContactsFromList();


        // Assert
        Assert.NotNull(result);
        Assert.True(result.Any());
        ICustomer returnedCustomer = result.FirstOrDefault()!;

    }
}
