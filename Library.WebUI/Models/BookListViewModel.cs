using Library.Domain.Entities;

namespace Library.WebUI.Models;

public class BookListViewModel
{
    public List<Book> Books { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
    public int CurrentPage { get; set; }
    public string Type { get; set; }
}
