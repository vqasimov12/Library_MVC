using Library.Domain.Abstracts;
using System.Linq.Expressions;

namespace Library.Repository.DataAccess;

public interface IEntityRepositoryBase<T> where T : class , IEntity, new()
{
    T Get(Expression<Func<T,bool>>filter=null);
    List<T> GetList(Expression<Func<T, bool>> filter = null);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}