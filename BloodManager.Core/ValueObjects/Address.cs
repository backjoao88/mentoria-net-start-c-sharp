namespace BloodManager.Core.ValueObjects;

public class Address
{
    public Address(string street, string city, string state, string postalCode)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
    }

    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
}