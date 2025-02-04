using Library.Domain.Entities;
using Library.Repository.DataAccess;

namespace Library.DataAccess.Abstract;

public interface IBookDal : IEntityRepositoryBase<Book>
{
    
}