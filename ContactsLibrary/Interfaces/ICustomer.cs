namespace ContactsLibrary.Interfaces;


/// <summary>
/// Interface for contact
/// </summary>
public interface ICustomer
{
    Guid Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }
    string City { get; set; }
    string Country { get; set; }
}
