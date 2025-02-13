using Cargo.Repository.Abstract;
using Cargo.Repository.Entities;

namespace Cargo.Repository.Concrete;

public class CarrierRepository : GenericRepository<Carrier>, ICarrierRepository
{
    public CarrierRepository(CargoDbContext context) : base(context)
    {
    }
}
