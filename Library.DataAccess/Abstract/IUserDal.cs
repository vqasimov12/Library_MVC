using Library.Domain.Entities;
using Library.Repository.DataAccess;

namespace Library.DataAccess.Abstract;

public interface IUserDal : IEntityRepositoryBase<User>
{
   
}