using Cargo.Repository.Abstract;
using Cargo.Repository.Entities;

namespace Cargo.Repository.Concrete;

public class CarrierConfigurationRepository : GenericRepository<CarriersConfiguration>, ICarrierConfigurationRepository
{
    public CarrierConfigurationRepository(CargoDbContext context) : base(context)
    {
    }
}
