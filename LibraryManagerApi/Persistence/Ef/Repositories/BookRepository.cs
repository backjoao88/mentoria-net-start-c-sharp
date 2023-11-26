using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Repositories;

namespace LibraryManagerApi.Persistence.Ef.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(DatabaseContext context) : base(context)
    {
    }

    public new IEnumerable<Book> FindAll()
    {
        return Context.Set<Book>().Where(o => !o.IsDeleted).ToList();
    }

    public Book? FindById(Guid id)
    {
        return Context.Set<Book>().SingleOrDefault(o => !o.IsDeleted && o.Id == id);
    }
}