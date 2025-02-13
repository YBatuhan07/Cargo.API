using Cargo.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cargo.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly CargoDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(CargoDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IQueryable<T> ListAll() => _dbSet.AsQueryable();

    public IQueryable<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).AsNoTracking();

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<T> AddAsync(T entity) => (await _dbSet.AddAsync(entity)).Entity;

    public T Update(T entity) => _dbSet.Update(entity).Entity;

    public T Delete(T entity) => _dbSet.Remove(entity).Entity;
}