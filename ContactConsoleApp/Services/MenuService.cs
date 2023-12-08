using ContactsLibrary.Interfaces;
using ContactsLibrary.Models;
using ContactsLibrary.Services;

namespace ContactConsoleApp.Services;

internal class MenuService
{
    private static readonly IContactservice _contactService = new ContactService(new FileService());

    public static void ShowMainMenu()
    {
        _contactService.GetAllContactsFromList();

        Console.WriteLine("Welcome to the Contact App");
        Console.WriteLine("Please select an option:");
        Console.WriteLine("1. Add a contact");
        Console.WriteLine("2. List all contacts and view contact information");
        Console.WriteLine("3. Exit");
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
                Console.WriteLine("Invalid option. Please try again.");
                ShowMainMenu();
                break;
        }
    }

    private static void AddContact()
    {
        IContact contact = new Contact();


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
        Console.WriteLine("Contact added successfully.");
        Console.WriteLine("");
        Console.WriteLine("Press any key to go back to main menu");
        Console.ReadKey();

        ShowMainMenu();
    }

    private static void ListAllContacts()
    {
        var contacts = _contactService.GetAllContactsFromList();
        if (contacts != null)
        {
            int counter = 1;
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{counter}. {contact.FirstName} {contact.LastName} <{contact.Email}>");
                Console.WriteLine("");
            }
            Console.WriteLine("please copy the Email of the contact you wish to view later");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Add a contact");
            Console.WriteLine("2. View a contacts details");
            Console.WriteLine("3. Delete a contact");
            Console.WriteLine("4. Back to main menu");
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
        }
    }

    private static void ShowSingleContact()
    {
        Console.Write("Enter email address: ");
        var email = Console.ReadLine();
        var contact = _contactService.GetSingleContact(email!);
        if (contact != null)
        {
            Console.WriteLine($"First Name: {contact.FirstName}");
            Console.WriteLine($"Last Name: {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
            Console.WriteLine($"City: {contact.City}");
            Console.WriteLine($"Country: {contact.Country}");
            Console.WriteLine("");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Back to main menu");
            Console.WriteLine("2. List all contacts");
            Console.WriteLine("3. Delete contact");
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

    private static void DeleteContact()
    {
        Console.Write("Enter email address: ");
        var email = Console.ReadLine();
        var contact = _contactService.GetSingleContact(email!);
        if (contact != null)
        {
            _contactService.RemoveContactFromList(email!);
            Console.WriteLine("Contact deleted successfully.");
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
