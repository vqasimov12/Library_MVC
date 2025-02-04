using Library.Domain.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Library.Domain.Entities;

public class Book : IEntity, IProductPrice
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Genre { get; set; }

    [Required]
    public  string Author { get; set; }

    [Range(10, 10000)]
    public int Pages { get; set; }

    [Range(0, int.MaxValue)]
    public int ReadCount { get; set; } = 0;

    [Required]
    public string Description { get; set; }

    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }

    [Range(0, 100)]
    public int Quantity { get; set; }
    public string BookImage { get; set; } = "Book.png";
    public List<User> Users { get; set; } = [];
    public List<Order> Orders { get; set; } = [];
    public Book()
    {

    }
}