using DevFreela.Core.Entities;

namespace DevFreela.Core.Models.InputModels;

public class FreelancerInputModel
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public List<Skill> Skills { get; set; } = null!;
}