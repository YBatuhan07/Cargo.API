namespace Cargo.Service.Dto.CarrierConfiguration;

public record CreateCarrierConfigurationRequest(int CarrierMaxDesi, int CarrierMinDesi, decimal CarrierCost, int CarrierId);