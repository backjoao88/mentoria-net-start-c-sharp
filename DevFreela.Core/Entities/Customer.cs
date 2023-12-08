namespace DevFreela.Core.Entities;

public class Customer : User
{
    public Customer(Guid id, string firstName, string lastName, string email, string role) : base(id, firstName, lastName, email, role)
    {
    }
}