namespace BloodManager.Core.Entities;

public class BaseEntity
{
    public Guid Id { get; private set; }
    public bool IsDeleted { get; private set; }
    
    public BaseEntity(){}
    
    public BaseEntity(Guid id)
    {
        Id = id;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}