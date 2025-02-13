using System.Linq.Expressions;

namespace Cargo.Repository.Abstract;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> ListAll();

    IQueryable<T> Where(Expression<Func<T, bool>> predicate);

    Task<T?> GetByIdAsync(int id);

    Task<T> AddAsync(T entity);

    T Update(T entity);

    T Delete(T entity);
}