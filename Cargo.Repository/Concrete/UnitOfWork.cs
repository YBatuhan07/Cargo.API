using Cargo.Repository.Abstract;

namespace Cargo.Repository.Concrete;

public class UnitOfWork : IUnitOfWork
{
    private readonly CargoDbContext _context;

    public UnitOfWork(CargoDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangeAsync() => await _context.SaveChangesAsync();
}
