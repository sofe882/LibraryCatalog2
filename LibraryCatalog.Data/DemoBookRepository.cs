using LibraryCatalog.Logic;

namespace LibraryCatalog.Data;

public class DemoBookRepository : IBookRepository
{
    public List<Book> GetAll()
    {
        return new List<Book>
        {
            new Book { Id = 100, Title = "Демонстрационная книга", Year = 1990 },
            new Book { Id = 101, Title = "Просто книга ", Year = 1985 }
        };
    }
}