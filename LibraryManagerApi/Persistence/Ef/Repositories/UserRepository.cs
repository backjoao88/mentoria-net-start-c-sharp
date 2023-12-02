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
        return Context.Set<User>().ToList();
    }

    public User? FindById(int id)
    {
        return Context.Set<User>().SingleOrDefault(o => o.Id == id);
    }
    
}