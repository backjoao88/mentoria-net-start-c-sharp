using System.Linq.Expressions;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
namespace LibraryManager.Database.Data
{
    public class UserRepository : IUserRepository
    {

        readonly EfContext _efContext;
        
        public UserRepository(EfContext efContext)
        {
            this._efContext = efContext;
        }

        public void Save(User user)
        {
            _efContext.Users.Add(user);
        }

        public void Remove(User user)
        {
            _efContext.Remove(user);
        }

        public List<User> Find(Expression<Func<User, bool>> predicate)
        {
            return _efContext.Users.Where(predicate).ToList();
        }

        public List<User> FindAll()
        {
            return _efContext.Users.ToList();
        }
    }
}