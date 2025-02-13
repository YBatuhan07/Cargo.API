using Cargo.Service.Dto.Order;

namespace Cargo.Service.Abstract;

public interface IOrderService
{
    Task<ServiceResult<OrderResponse>> CreateAsync(CreateOrderRequest request);
}
