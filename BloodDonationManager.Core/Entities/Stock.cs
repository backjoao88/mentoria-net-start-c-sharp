using BloodDonationManager.Core.Entities.Interfaces;
using BloodDonationManager.Core.Enums;

namespace BloodDonationManager.Core.Entities;

public class Stock : IIdentificable, IDeletable
{
    public Stock(int id, BloodType bloodType, RhFactorType rhFactor, int quantityMl)
    {
        Id = id;
        BloodType = bloodType;
        RhFactor = rhFactor;
        QuantityMl = quantityMl;
    }
    public int Id { get; private set; }
    public BloodType BloodType { get; private set; }
    public RhFactorType RhFactor { get; private set; }
    public int QuantityMl { get; private set; }
    public bool IsDeleted { get; private set; }
    public void Delete()
    {
        IsDeleted = true;
    }
}