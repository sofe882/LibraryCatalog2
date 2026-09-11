using System.Xml.Serialization;
using LibraryCatalog.Logic;

namespace LibraryCatalog.Data;

public class XmlBookRepository : IBookRepository
{
    private readonly string _path;
    private readonly XmlSerializer _serializer = new(typeof(List<Book>));

    public XmlBookRepository(string path)
    {
        _path = path;
    }

    public List<Book> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Book>();
        }

        using var reader = new StreamReader(_path);
        return _serializer.Deserialize(reader) as List<Book> ?? new List<Book>();
    }

    public void Add(Book item)
    {
        List<Book> items = GetAll();
        items.Add(item);

        using var writer = new StreamWriter(_path);
        _serializer.Serialize(writer, items);
    }
}
