using Library.Domain.Entities;

namespace Library.Application.Abstract;

public interface ICourseService
{
    List<User> GetUsers(int courseId);
    List<Course> GetCoursesByUser(int userId);
    List<Order> GetOrdersByCourse(int courseId);
    List<Course> GetCoursesByOrder(int orderId);
    List<Course> GetAll();
    Course GetById(int id);
    void Add(Course course);
    void Update(Course course);
    void Delete(int id);
}