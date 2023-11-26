using LibraryManagerApi.Core.Entities;

namespace LibraryManagerApi.Core.Repositories;

public interface IUserRepository : IRepository<User>
{
    public User? FindById(Guid id);
}