using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryCatalog.Logic;   

namespace LibraryCatalog.Data;

public class BookRepository : IBookRepository
{
    private readonly List<Book> _books = new()
    {
        new Book { Id = 1, Title = "Война и мир", Year = 1869 },
        new Book { Id = 2, Title = "1984", Year = 1949 },
        new Book { Id = 3, Title = "Мастер и Маргарита", Year = 1967 },
        new Book { Id = 4, Title = "Гарри Поттер и философский камень", Year = 1997 },
        new Book { Id = 5, Title = "Три товарища", Year = 1936 },
        new Book { Id = 6, Title = "Алгоритмы: построение и анализ", Year = 2009 }
    };

    public List<Book> GetAll() => _books;
    public void Add(Book item)
    {
        _books.Add(item);
    }
}