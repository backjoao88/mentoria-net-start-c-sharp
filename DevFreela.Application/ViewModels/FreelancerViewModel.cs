namespace DevFreela.Application.ViewModels;

public class FreelancerViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public List<SkillViewModel> Skills { get; set; } = null!;
}