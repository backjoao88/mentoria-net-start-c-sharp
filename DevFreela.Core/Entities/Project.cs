using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities;

public class Project
{
    public Project(Guid idCustomer, Guid idFreelancer, string description, decimal cost, DateTime createdAt, DateTime startedAt, DateTime finishedAt, ProjectStatus status, List<ProjectComment> comments)
    {
        IdCustomer = idCustomer;
        IdFreelancer = idFreelancer;
        Description = description;
        Cost = cost;
        CreatedAt = createdAt;
        StartedAt = startedAt;
        FinishedAt = finishedAt;
        Status = status;
        Comments = comments;
    }

    public Guid Id { get; private set; }
    public Guid IdCustomer { get; private set; }
    public Guid IdFreelancer { get; private set; }
    public string Description { get; private set; } = "";
    public decimal Cost { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime FinishedAt { get; private set; }
    public ProjectStatus Status { get; private set; }
    public List<ProjectComment> Comments { get; private set; }
}