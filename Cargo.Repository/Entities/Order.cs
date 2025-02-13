namespace Cargo.Repository.Entities;

public class Order
{
    public int OrderId { get; set; }
    public int OrderDesi { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal OrderCarrierCost { get; set; }
    public int CarrierId { get; set; }
    public Carrier? Carrier { get; set; }
}
