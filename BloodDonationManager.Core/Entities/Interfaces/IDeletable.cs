namespace BloodDonationManager.Core.Entities.Interfaces;

public interface IDeletable
{
    public bool IsDeleted { get; }
    public void Delete();
}