using LibraryCatalog.Logic;

var service = new BookService();
Console.WriteLine("Книги, изданные до 2000 года:");
foreach (var book in service.GetOldBooks())
{
    Console.WriteLine($"{book.Id}: {book.Title} ({book.Year})");
}