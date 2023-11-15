using LibraryManager.Core.Models;
namespace LibraryManager.Core.Data
{
    public interface IUserRepository
    {
        public void Save(User user);
        public void Remove(User user);
        public List<User> FindAll();
    }
}