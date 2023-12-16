namespace BloodManager.Application.ViewModels;

public class DonorViewModel
{
    public DonorViewModel(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}