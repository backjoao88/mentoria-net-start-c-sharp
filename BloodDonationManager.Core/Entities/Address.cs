namespace BloodDonationManager.Core.Entities;

public class Address
{
    public Address()
    {
    }

    public Address(int idDonor, string street, string city, string state, string cep)
    {
        IdDonor = idDonor;
        Street = street;
        City = city;
        State = state;
        Cep = cep;
    }
    
    public int IdDonor { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Cep { get; private set; }
}