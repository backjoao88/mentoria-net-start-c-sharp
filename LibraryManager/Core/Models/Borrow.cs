namespace LibraryManager.Core.Models
{
    public class Borrow
    {
        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime? Devolution { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public Borrow(int id, int idUser, int idBook, DateTime start, DateTime end)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            Start = start;
            End = end;
            Book = null!;
            User = null!;
        }

        public override string ToString()
        {
            return $"Id: {Id}, IdUser: {IdUser}, User: {User}, IdBook: {IdBook}, Book: {Book}, Devolution: {Devolution}, Start: {Start}, End: {End}";
        }

    }
}