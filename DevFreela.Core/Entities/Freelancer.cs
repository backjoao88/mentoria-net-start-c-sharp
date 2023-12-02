namespace DevFreela.Core.Entities;

public class Freelancer : User
{
    public Freelancer(string firstName, string lastName, string email, string role, List<Skill> skills) : base(firstName, lastName, email, role)
    {
        Skills = skills;
    }

    public List<Skill> Skills { get; private set; }
}