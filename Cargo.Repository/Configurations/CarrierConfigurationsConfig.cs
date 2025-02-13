using Cargo.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cargo.Repository.Configurations;

public class CarrierConfigurationsConfig : IEntityTypeConfiguration<CarriersConfiguration>
{
    public void Configure(EntityTypeBuilder<CarriersConfiguration> builder)
    {
        builder.HasKey(x => x.CarrierConfigurationId);
    }
}
