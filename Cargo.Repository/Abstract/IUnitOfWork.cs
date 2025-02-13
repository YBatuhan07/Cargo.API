namespace Cargo.Repository.Abstract;

public interface IUnitOfWork
{
    Task<int> SaveChangeAsync();
}
