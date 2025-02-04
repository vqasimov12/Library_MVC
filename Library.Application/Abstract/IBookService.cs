using Library.Domain.Entities;

namespace Library.Application.Abstract;

public interface IBookService
{
    List<User> GetUsers(int bookId);
    List<Book> GetBooksByUser(int userId);
    List<Order> GetOrdersByBook(int bookId);
    List<Book> GetBooksByOrder(int orderId);
    List<Book> GetAll();
    Book GetById(int id);
    void Add(Book book);
    void Update(Book book);
    void Delete(int id);
}
