using Library.Domain.Entities;

namespace Library.WebUI.Models;

public class CourseAddViewModel
{
    public Course Course{ get; set; }
    public string? CourseImage { get; set; }
}
