using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Repositories;

namespace LibraryManagerApi.Persistence.Ef.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(DatabaseContext context) : base(context)
    {
    }

    public Book? FindById(Guid id)
    {
        return Context.Set<Book>().SingleOrDefault(o => o.Id == id);
    }
}