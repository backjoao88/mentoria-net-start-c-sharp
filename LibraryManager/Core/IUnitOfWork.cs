using LibraryManager.Core.Data;
namespace LibraryManager.Core
{
    public interface IUnitOfWork
    {
        public IBookData BookData { get; }
        public int Complete();
    }
}