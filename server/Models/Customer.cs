using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public virtual List<Address>? Addresses { get; set; }
}

public class Address
{
    [Key]
    public int Id { get; set; }
    public string StreetName { get; set; }
    public int StreetNo { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public bool Primary { get; set; }
    public int CustomerId { get; set; }
}