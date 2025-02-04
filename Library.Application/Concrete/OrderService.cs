using Library.Application.Abstract;
using Library.DataAccess.Abstract;
using Library.Domain.Entities;

namespace Library.Application.Concrete;

public class OrderService(IOrderDal orderDal) : IOrderService
{

    private readonly IOrderDal _orderDal = orderDal;

    public List<Book> GetBooks(int orderId) =>
        [.. _orderDal.Get(x => x.Id == orderId).Books];

    public List<Course> GetCourses(int orderId) =>
        [.. _orderDal.Get(x => x.Id == orderId).Courses];

    public List<Order> GetOrdersByBook(int bookId) =>
       [.. _orderDal.GetList(x => x.Books.Any(b => b.Id  == bookId))];

    public List<Order> GetOrdersByCourse(int courseId) =>
        [.. _orderDal.GetList(x => x.Courses.Any(c => c.Id == courseId))];

    public List<Order> GetOrdersByUser(int userId) =>
        _orderDal.GetList(x => x.User.Id == userId);

    public User GetUser(int orderId) =>
        _orderDal.Get(x => x.Id == orderId).User;

    public List<Order> GetAll() =>
        _orderDal.GetList();

    public Order GetById(int id) =>
        _orderDal.Get(x => x.Id == id);
}
