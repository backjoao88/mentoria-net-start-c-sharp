using DevFreela.Core.Entities;

namespace DevFreela.Core.Models.ViewModels;

public class FreelancerViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public List<Skill> Skills { get; set; } = null!;
}