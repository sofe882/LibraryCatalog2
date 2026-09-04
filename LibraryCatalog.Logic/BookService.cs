using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryCatalog.Data;

namespace LibraryCatalog.Logic;

public class BookService
{
    private readonly BookRepository _repository = new();

    public List<Book> GetOldBooks() => _repository.GetAll()
        .Where(book => book.Year < 2000)
        .ToList();
}
