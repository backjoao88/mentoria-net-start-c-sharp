using DevFreela.Core.Entities;

namespace DevFreela.Core.Models.ViewModels;

public class ProjectViewModel
{
    public Guid Id { get; set; }
    public Guid IdCustomer { get; set; }
    public Customer Customer { get; set; } = null!;
    public Guid IdFreelancer { get; set; }
    public Freelancer Freelancer { get; set; } = null!;
    public string Description { get; set; } = "";
    public decimal Cost { get; set; }
}