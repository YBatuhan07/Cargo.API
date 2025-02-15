using AutoMapper;
using Cargo.Repository.Abstract;
using Cargo.Repository.Entities;
using Cargo.Service.Abstract;
using Cargo.Service.Dto.Order;
using Microsoft.EntityFrameworkCore;

namespace Cargo.Service.Concrete;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper, ICarrierConfigurationRepository carrierConfigurationRepository)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _carrierConfigurationRepository = carrierConfigurationRepository;
    }

    public async Task<ServiceResult<OrderResponse>> CreateAsync(CreateOrderRequest request)
    {
        var order = _mapper.Map<Order>(request);

        var machingConfigurations = await _carrierConfigurationRepository.Where(x => x.CarrierMinDesi <= request.OrderDesi && x.CarrierMaxDesi >= request.OrderDesi).ToListAsync();

        if (!machingConfigurations.Any())
        {
            return ServiceResult<OrderResponse>.Fail("Uygun kargo firması bulunamadı");
        }
        var selectedConiguration = machingConfigurations.OrderBy(x => x.CarrierCost).First();

        order.OrderCarrierCost = selectedConiguration.CarrierCost;
        order.CarrierId = selectedConiguration.CarrierId;

        var result = await _orderRepository.AddAsync(order);
        await _unitOfWork.SaveChangeAsync();
        var orderResponse = _mapper.Map<OrderResponse>(result);

        return ServiceResult<OrderResponse>.Success(orderResponse);
    }

    #region CreateAsync

    //public async Task<ServiceResult<OrderResponse>> CreateAsync(CreateOrderRequest request)
    //{
    //    var order = _mapper.Map<Order>(request);
    //    var result = await _orderRepository.AddAsync(order);
    //    await _unitOfWork.SaveChangeAsync();
    //    var orderResponse = _mapper.Map<OrderResponse>(result);

    //    return ServiceResult<OrderResponse>.Success(orderResponse);
    //}

    #endregion Create
}