namespace DevFreela.Core.Entities;

public class Customer : User
{
    public Customer(string firstName, string lastName, string email, string role) : base(firstName, lastName, email, role)
    {
    }
}