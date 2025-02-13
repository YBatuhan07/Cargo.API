namespace Cargo.Service.Dto.Order;

public class OrderResponse
{
    public int OrderId { get; set; }
    public decimal OrderCarrierCost { get; set; }
    public DateTime OrderDate { get; set; }
}
