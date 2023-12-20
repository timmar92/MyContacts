using ContactsLibrary.Interfaces;

namespace ContactsLibrary.Models;

/// <summary>
/// Contact class
/// </summary>
public class Customer : ICustomer
{
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
}
