using Library.Domain.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Course : IEntity,IProductPrice
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Duration { get; set; }
    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }
    [Required]
    public string RequiredSkills { get; set; }
    [Required]
    public string Mentor { get; set; }
    public string CourseLink { get; set; }
    public string? CourseImage { get; set; } = "DefaultCourse.png";
    public List<User> Users { get; set; } = [];
    public List<Order> Orders { get; set; } = [];
    public Course()
    {
        CourseLink = "https://www.youtube.com/embed/JFO_HLa0UMc";
    }
}