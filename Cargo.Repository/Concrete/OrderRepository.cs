using Cargo.Repository.Abstract;
using Cargo.Repository.Entities;

namespace Cargo.Repository.Concrete;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(CargoDbContext context) : base(context)
    {
    }
}