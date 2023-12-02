using DevFreela.Core.Entities.Interfaces;

namespace DevFreela.Core.Entities;

public class Skill : ISoftDeletable, IAuditable
{
    public Skill(string description, bool isDeleted, DateTime createdAt)
    {
        Description = description;
        IsDeleted = isDeleted;
        CreatedAt = createdAt;
    }

    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public bool IsDeleted { get; }
    public DateTime CreatedAt { get; }
}