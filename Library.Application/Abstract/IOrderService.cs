using Library.Domain.Entities;

namespace Library.Application.Abstract;

public interface IOrderService
{
    public User GetUser(int orderId);
    List<Order> GetOrdersByUser(int userId);
    List<Book> GetBooks(int orderId);
    List<Order> GetOrdersByBook(int bookId);
    List<Course> GetCourses(int orderId);
    List<Order> GetOrdersByCourse(int courseId);
    List<Order> GetAll();
    Order GetById(int id);
}