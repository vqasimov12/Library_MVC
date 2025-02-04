using Library.Domain.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Library.Domain.Entities;

public class User:IEntity
{
    [Key]
    [Column("UserID")]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Surname { get; set; }
    [Range(7, 100)]
    public int Age { get; set; } = 0;
    [Required]
    public string Speciality { get; set; }
    public string? ProfileImage { get; set; } = "DefaultUser.png";
    public List<Order> Orders { get; set; } = [];
    public List<Course> Courses { get; set; } = [];
    public List<Book> Books { get; set; } = [];
    public User()
    {
        ProfileImage = "DefaultUser.png";
    }
}