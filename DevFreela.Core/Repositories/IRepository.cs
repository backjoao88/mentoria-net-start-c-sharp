namespace DevFreela.Core.Repositories;

public interface IRepository<T> where T : class
{
    public void Save(T data);
    public List<T> FindAll();
}