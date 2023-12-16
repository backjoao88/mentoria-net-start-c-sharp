using BloodManager.Core.Enums;

namespace BloodManager.Core.Entities;

public class Stock : BaseEntity
{
    public Stock()
    {
    }

    public Stock(Guid id) : base(id)
    {
    }

    public Stock(BloodType bloodType, RhFactorType rhFactorType, string description)
    {
        BloodType = bloodType;
        RhFactorType = rhFactorType;
        Quantity = 0;
        Description = description;
    }

    public string Description { get; private set; } = "";
    public BloodType BloodType { get; private set; }
    public RhFactorType RhFactorType { get; private set; }
    public int Quantity { get; private set; }

    public void Increase(int quantityMl)
    {
        Quantity += quantityMl;
    }

    public void Decrease(int quantityMl)
    {
        Quantity -= quantityMl;
    }
    
}