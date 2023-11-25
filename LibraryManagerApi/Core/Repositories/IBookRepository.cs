using LibraryManagerApi.Core.Entities;

namespace LibraryManagerApi.Core.Repositories;

public interface IBookRepository : IRepository<Book>
{
    public Book? FindById(Guid Id);
}