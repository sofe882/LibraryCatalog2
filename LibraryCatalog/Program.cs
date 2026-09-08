
using LibraryCatalog.Data;
using LibraryCatalog.Logic;


IBookRepository repository = new BookRepository();   

var service = new BookService(repository);

Console.WriteLine("Книги, изданные до 2000 года:");
foreach (var book in service.GetOldBooks())
{
    Console.WriteLine($"{book.Id}: {book.Title} ({book.Year})");
}