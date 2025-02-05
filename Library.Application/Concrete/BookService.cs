using Library.Application.Abstract;
using Library.DataAccess.Abstract;
using Library.DataAccess.Concrete.EfEntityFramework;
using Library.Domain.Entities;
using Newtonsoft.Json;

namespace Library.Application.Concrete;

public class BookService(IBookDal bookDal) : IBookService
{
    private readonly IBookDal _bookDal = bookDal;

    public List<Book> GetBooksByOrder(int orderId) =>
        _bookDal.GetList(x => x.Orders.Any(o => o.Id == orderId));

    public List<Book> GetBooksByUser(int userId) =>
        _bookDal.GetList(x => x.Users.Any(u => u.Id == userId));

    public List<Order> GetOrdersByBook(int bookId) =>
        [.. _bookDal.Get(x => x.Id == bookId).Orders];

    public List<User> GetUsers(int bookId) =>
        [.. _bookDal.Get(x => x.Id == bookId).Users.ToList()];

    public List<Book> GetAll() =>
        _bookDal.GetList();

    public Book GetById(int id) =>
        _bookDal.Get(x => x.Id == id);

    public void Add(Book book) =>
        _bookDal.Add(book);

    public void Update(Book book) =>
        _bookDal.Update(book);

    public void Delete(int id) =>
         _bookDal.Delete(_bookDal.Get(z => z.Id == id));
}