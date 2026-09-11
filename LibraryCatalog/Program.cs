using LibraryCatalog.Data;
using LibraryCatalog.Logic;

string jsonPath = Path.Combine(AppContext.BaseDirectory, "books.json");
string xmlPath = Path.Combine(AppContext.BaseDirectory, "books.xml");

string kind = args.Length > 0 ? args[0] : "json";

IBookRepository repository = kind switch
{
    "xml" => new XmlBookRepository(xmlPath),
    "memory" => new BookRepository(),
    _ => new JsonBookRepository(jsonPath)
};

Console.WriteLine($"Хранилище: {kind}");

var service = new BookService(repository);

Console.WriteLine("Название новой книги:");
string title = Console.ReadLine() ?? "";

Console.WriteLine("Год издания:");
string yearInput = Console.ReadLine() ?? "";
int year = int.TryParse(yearInput, out var y) ? y : 2000;

service.AddBook(title, year);

Console.WriteLine("Книги, изданные до 2000 года:");
foreach (var book in service.GetOldBooks())
{
    Console.WriteLine($"{book.Id}: {book.Title} ({book.Year})");
}

Console.WriteLine("Самая старая книга в каталоге:");
var oldest = service.GetOldestBook();
if (oldest != null)
{
    Console.WriteLine($"{oldest.Id}: {oldest.Title} ({oldest.Year})");
}
else
{
    Console.WriteLine("Каталог пуст");
}