using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.context;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Course> Courses { get; set; }

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

    public LibraryDbContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
