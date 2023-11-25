using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Repositories;

namespace LibraryManagerApi.Persistence.Ef.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context)
    {
    }
}