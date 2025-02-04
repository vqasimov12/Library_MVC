
using Library.Domain.Abstracts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Order:IEntity
{
    [Key]
    [Column("OrderID")]
    public int Id { get; set; }

    [NotMapped]
    public string Name { get; set; }
    public int UserID { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public User User { get; set; }
    public List<Book> Books { get; set; } = [];
    public List<Course> Courses { get; set; } = [];  
}