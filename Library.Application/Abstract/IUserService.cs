using Library.Domain.Entities;

namespace Library.Application.Abstract;

public interface IUserService
{
    List<Course> GetCourses(int userId);
    List<User> GetUsersByCourse(int courseId);
    List<Order> GetOrdersByUser(int userId);
    List<Book> GetBooks(int userId);
    List<User> GetUsersByBook(int bookId);
    User GetUserByOrder(int orderId);
    List<User> GetAll();
    User GetById(int id);
    void Add(User user);
    void Update(User user);
    void Delete(int userId);
}