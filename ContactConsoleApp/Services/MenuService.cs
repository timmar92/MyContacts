using ContactConsoleApp.Interfaces;
using ContactsLibrary.Interfaces;
using ContactsLibrary.Models;
using ContactsLibrary.Services;

namespace ContactConsoleApp.Services;

internal class MenuService : IMenuService
{
    private readonly IContactservice _contactService = new ContactService(new FileService());

    /// <summary>
    /// shows the main menu
    /// </summary>
    public void ShowMainMenu()
    {
        _contactService.GetAllContactsFromList();
        Console.Clear();
        Console.WriteLine("Welcome to the Contact App");
        Console.WriteLine("");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("");
        Console.WriteLine("1. Add a contact");
        Console.WriteLine("2. List all contacts and view contact information");
        Console.WriteLine("3. Exit");
        Console.WriteLine("");
        Console.Write("Enter your choice: ");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                AddContact();
                break;
            case "2":
                ListAllContacts();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("");
                Console.WriteLine("Invalid option. Please try again.");
                ShowMainMenu();
                break;
        }
    }

    /// <summary>
    /// adds a contact to the list by taking user input and calling the AddContactToList method from the ContactService class
    /// </summary>
    public void AddContact()
    {
        IContact contact = new Contact();

        Console.Clear();
        Console.Write("Enter first name: ");
        contact.FirstName = Console.ReadLine()!;
        Console.WriteLine("");
        Console.Write("Enter last name: ");
        contact.LastName = Console.ReadLine()!;
        Console.WriteLine("");
        Console.Write("Enter email address: ");
        contact.Email = Console.ReadLine()!;
        Console.WriteLine("");
        Console.Write("Enter phone number: ");
        contact.PhoneNumber = Console.ReadLine()!;
        Console.WriteLine("");
        Console.Write("Enter city: ");
        contact.City = Console.ReadLine()!;
        Console.WriteLine("");
        Console.Write("Enter country: ");
        contact.Country = Console.ReadLine()!;

        _contactService.AddContactToList(contact);
        Console.WriteLine("");
        Console.WriteLine("Contact added successfully.");
        Console.WriteLine("");
        Console.WriteLine("Press any key to go back to main menu");
        Console.ReadKey();

        ShowMainMenu();
    }

    /// <summary>
    /// lists all contacts in the list by calling the GetAllContactsFromList method from the ContactService class and asigning a number to each contact
    /// </summary>
    public void ListAllContacts()
    {
        Console.Clear();
        var contacts = _contactService.GetAllContactsFromList();
        if (contacts != null && contacts.Any())
        {
            int counter = 1;
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{counter}. {contact.FirstName} {contact.LastName} <{contact.Email}>");
                counter++;
                Console.WriteLine("");
            }
            Console.WriteLine("please copy the Email of the contact you wish to view later");
            Console.WriteLine("");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. View a contacts details");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. Back to main menu");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ShowSingleContact();
                    break;
                case "3":
                    DeleteContact();
                    break;
                case "4":
                    ShowMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    ListAllContacts();
                    break;
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
            Console.WriteLine("Press any key to go back to main menu");
            ShowMainMenu();
        }
    }

    /// <summary>
    /// shows a single contact by taking user input and calling the GetSingleContact method from the ContactService class
    /// </summary>
    public void ShowSingleContact()
    {
        Console.Clear();
        Console.Write("Enter email address: ");
        var email = Console.ReadLine();
        var contact = _contactService.GetSingleContact(email!);
        if (contact != null)
        {
            Console.WriteLine("");
            Console.WriteLine($"First Name: {contact.FirstName}");
            Console.WriteLine($"Last Name: {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"City: {contact.City}");
            Console.WriteLine($"Country: {contact.Country}");
            Console.WriteLine("");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("");
            Console.WriteLine("1. Back to main menu");
            Console.WriteLine("2. List all contacts");
            Console.WriteLine("3. Delete contact");
            Console.WriteLine("");
            Console.Write("Enter your choice: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    ShowMainMenu();
                    break;
                case "2":
                    ListAllContacts();
                    break;
                case "3":
                    DeleteContact();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    ShowSingleContact();
                    break;
            }
        }
        else
        {
            Console.WriteLine("No contact found with the given email address.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
            ShowMainMenu();
        }

    }

    /// <summary>
    /// deletes a contact by taking user input and calling the RemoveContactFromList method from the ContactService class
    /// </summary>
    public void DeleteContact()
    {
        Console.Clear();
        Console.Write("Enter email address: ");
        var email = Console.ReadLine();
        var contact = _contactService.GetSingleContact(email!);
        if (contact != null)
        {
            Console.WriteLine("");
            Console.WriteLine("Are you sure you want to delete this contact? (y/n)");
            var confirmation = Console.ReadLine();
            if (confirmation?.ToLower() == "y")
            {
                _contactService.RemoveContactFromList(email!);
                Console.WriteLine("");
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Contact deletion cancelled.");
            }
            Console.WriteLine("");
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
            ShowMainMenu();
        }
        else
        {
            Console.WriteLine("No contact found with the given email address.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
            ShowMainMenu();
        }
    }
}
