using Library.Application.Abstract;
using Library.DataAccess.Abstract;
using Library.Domain.Entities;

namespace Library.Application.Concrete;

public class CourseService(ICourseDal courseDal) : ICourseService
{
    private readonly ICourseDal _courseDal = courseDal;

    public List<Course> GetCoursesByOrder(int orderId) =>
     [.. _courseDal.GetList(c => c.Orders.Any(o => o.Id == orderId))];

    public List<Course> GetCoursesByUser(int userId) =>
     [.. _courseDal.GetList(c => c.Users.Any(u => u.Id == userId))];

    public List<Order> GetOrdersByCourse(int courseId) =>
        [.. _courseDal.Get(c => c.Id == courseId).Orders];

    public List<User> GetUsers(int courseId) =>
    [.. _courseDal.Get(c => c.Id == courseId).Users];

    public List<Course> GetAll() =>
        _courseDal.GetList();

    public Course GetById(int id) =>
        _courseDal.Get(c => c.Id == id);

    public void Add(Course course) =>
        _courseDal.Add(course);

    public void Update(Course course) =>
        _courseDal.Update(course);

    public void Delete(int id) =>
        _courseDal.Delete(_courseDal.Get(c => c.Id == id));
}
