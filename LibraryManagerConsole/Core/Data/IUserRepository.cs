using System.Linq.Expressions;
using LibraryManagerConsole.Core.Models;
namespace LibraryManagerConsole.Core.Data
{
    public interface IUserRepository
    {
        public void Save(User user);
        public void Remove(User user);
        public List<User> Find(Expression<Func<User, bool>> predicate);
        public List<User> FindAll();
    }
}