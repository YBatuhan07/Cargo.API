namespace Cargo.Repository.Entities;

public class Carrier
{
    public int CarrierId { get; set; }
    public string CarrierName { get; set; } = null!;
    public bool CarrierIsActive { get; set; }
    public int CarrierPlusDesiCost { get; set; }
    public List<CarriersConfiguration> CarriersConfigurations { get; set; } = new();
}
