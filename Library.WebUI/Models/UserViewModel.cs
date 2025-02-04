using Library.Domain.Entities;

namespace Library.WebUI;

public class UserViewModel
{
    public List<User> Users { get; set; }
    public int PageSize { get; set; }
    public int PageCount { get; set; }
    public int CurrentPage { get; set; }
    public string Type { get; set; }
}