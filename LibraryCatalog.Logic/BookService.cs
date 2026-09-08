using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryCatalog.Logic;

public class BookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public List<Book> GetOldBooks()
    {
        return _repository.GetAll()
            .Where(book => book.Year < 2000)
            .ToList();
    }
}
