using Library.Application.Abstract;
using Library.DataAccess.Abstract;
using Library.Domain.Entities;

namespace Library.Application.Concrete;

public class UserService(IUserDal userDal) : IUserService
{
    private readonly IUserDal _userDal = userDal;

    public List<Book> GetBooks(int userId) =>
        [.. _userDal.Get(z => z.Id == userId).Books];

    public List<Course> GetCourses(int userId) =>
        [.. _userDal.Get(z => z.Id == userId).Courses];

    public List<Order> GetOrdersByUser(int userId) =>
        [.. _userDal.Get(z => z.Id == userId).Orders];

    public User GetUserByOrder(int orderId) =>
        _userDal.Get(z => z.Orders.Any(x => x.Id == orderId));

    public List<User> GetUsersByBook(int bookId) =>
        [.. _userDal.GetList(z => z.Books.Any(x => x.Id == bookId))];

    public List<User> GetUsersByCourse(int courseId) =>
        [.. _userDal.GetList(z => z.Courses.Any(x => x.Id == courseId))];

    public List<User> GetAll() =>
        _userDal.GetList();

    public User GetById(int id) =>
        _userDal.Get(z => z.Id == id);

    public void Add(User user) =>
        _userDal.Add(user);

    public void Update(User user) =>
        _userDal.Update(user);

    public void Delete(int userId) =>
        _userDal.Delete(_userDal.Get(z => z.Id == userId));

}
