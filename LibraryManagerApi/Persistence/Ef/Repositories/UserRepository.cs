using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Repositories;

namespace LibraryManagerApi.Persistence.Ef.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }

    public new IEnumerable<User> FindAll()
    {
        return Context.Set<User>().Where(o => !o.IsDeleted).ToList();
    }

    public User? FindById(Guid id)
    {
        return Context.Set<User>().SingleOrDefault(o => !o.IsDeleted && o.Id == id);
    }
    
}