using System.Text.Json;
using System.Text.Encodings.Web;
using LibraryCatalog.Logic;

namespace LibraryCatalog.Data;

public class JsonBookRepository : IBookRepository
{
    private readonly string _path;

    private readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    public JsonBookRepository(string path)
    {
        _path = path;
    }

    public List<Book> GetAll()
    {
        if (!File.Exists(_path))
        {
            return new List<Book>();
        }

        string text = File.ReadAllText(_path);

        try
        {
            return JsonSerializer.Deserialize<List<Book>>(text) ?? new List<Book>();
        }
        catch (JsonException)
        {
            return new List<Book>();
        }
    }

    public void Add(Book item)
    {
        List<Book> items = GetAll();
        items.Add(item);

        string text = JsonSerializer.Serialize(items, _options);
        File.WriteAllText(_path, text);
    }
}
