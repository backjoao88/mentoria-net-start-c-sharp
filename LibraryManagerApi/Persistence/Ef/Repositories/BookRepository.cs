using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerApi.Persistence.Ef.Repositories;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(DatabaseContext context) : base(context)
    {
    }
    public new IEnumerable<Book> FindAll()
    {
        return Context.Set<Book>().ToList();
    }

    public Book? FindById(int id)
    {
        return Context.Set<Book>().SingleOrDefault(o => o.Id == id);
    }
}