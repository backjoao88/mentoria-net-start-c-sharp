namespace DevFreela.Application.ViewModels;

public class ProjectViewModel
{
    public Guid Id { get; set; }
    public Guid IdCustomer { get; set; }
    public CustomerViewModel Customer { get; set; } = null!;
    public Guid IdFreelancer { get; set; }
    public FreelancerViewModel Freelancer { get; set; } = null!;
    public string Description { get; set; } = "";
    public decimal Cost { get; set; }
}