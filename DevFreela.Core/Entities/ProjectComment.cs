namespace DevFreela.Core.Entities;

public class ProjectComment
{
    public ProjectComment(Guid idUser, Guid idProject, string content)
    {
        IdUser = idUser;
        IdProject = idProject;
        Content = content;
    }
    
    public Guid Id { get; private set; }
    public Guid IdUser { get; private set; }
    public Guid IdProject { get; private set; }
    public string Content { get; private set; }
}