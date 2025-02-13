using Cargo.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Cargo.Repository;

public class CargoDbContext : DbContext
{
    public CargoDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Carrier> Carriers { get; set; }
    public DbSet<Carrier> CarrierConfigurations { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
