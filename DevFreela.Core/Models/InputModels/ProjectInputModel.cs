using DevFreela.Core.Enums;

namespace DevFreela.Core.Models.InputModels;

public class ProjectInputModel
{
    public Guid IdClient { get; set; }
    public Guid IdFreelancer { get; set; }
    public string Description { get; set; } = "";
    public decimal Cost { get; set; }
    public DateTime StartedAt { get; set; }
    public ProjectStatus Status { get; set; }
}