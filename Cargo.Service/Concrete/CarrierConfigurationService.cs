using AutoMapper;
using Cargo.Repository.Abstract;
using Cargo.Repository.Entities;
using Cargo.Service.Abstract;
using Cargo.Service.Dto.CarrierConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Cargo.Service.Concrete;

public class CarrierConfigurationService : ICarrierConfigurationService
{
    private readonly ICarrierConfigurationRepository _carrierConfigurationRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CarrierConfigurationService(ICarrierConfigurationRepository carrierConfigurationRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _carrierConfigurationRepository = carrierConfigurationRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ServiceResult<List<CarriersConfigurationDto>>> GetAllCarrierConfigurationsAsync()
    {
        var result = await _carrierConfigurationRepository.ListAll().ToListAsync();

        var dto = _mapper.Map<List<CarriersConfigurationDto>>(result);

        if (result is null) return ServiceResult<List<CarriersConfigurationDto>>.Fail("Kargo Firmaları bulunamadı");

        return ServiceResult<List<CarriersConfigurationDto>>.Success(dto);
    }

    public async Task<ServiceResult<CarriersConfigurationDto>> GetCarrierConfigurationByIdAsync(int id)
    {
        var result = await _carrierConfigurationRepository.GetByIdAsync(id);
        if (result is null) return ServiceResult<CarriersConfigurationDto>.Fail("Kargo Firması bulunamadı");

        var dto = _mapper.Map<CarriersConfigurationDto>(result);

        return ServiceResult<CarriersConfigurationDto>.Success(dto);
    }

    public async Task<ServiceResult<CarriersConfigurationDto>> CreateCarrierConfigurationAsync(CreateCarrierConfigurationRequest request)
    {
        var addRequest = _mapper.Map<CarriersConfiguration>(request);

        var result = await _carrierConfigurationRepository.AddAsync(addRequest);
        await _unitOfWork.SaveChangeAsync();

        var dto = _mapper.Map<CarriersConfigurationDto>(result);

        return ServiceResult<CarriersConfigurationDto>.Success(dto);
    }

    public async Task<ServiceResult<CarriersConfigurationDto>> UpdateCarrierConfigurationAsync(int id, CreateCarrierConfigurationRequest request)
    {
        var result = await _carrierConfigurationRepository.GetByIdAsync(id);
        if (result is null) return ServiceResult<CarriersConfigurationDto>.Fail("Kargo Firması bulunamadı");

        var isResultExist = await _carrierConfigurationRepository.Where(x => x.CarrierConfigurationId != id && x.CarrierMinDesi == request.CarrierMinDesi && x.CarrierMaxDesi == request.CarrierMaxDesi && x.CarrierId == request.CarrierId && x.CarrierCost ==request.CarrierCost).AnyAsync();

        if (isResultExist) return ServiceResult<CarriersConfigurationDto>.Fail("Bu aralıkta bir kargo firması zaten mevcut");

        result = _mapper.Map(request, result);
        _carrierConfigurationRepository.Update(result);
        await _unitOfWork.SaveChangeAsync();

        var dto = _mapper.Map<CarriersConfigurationDto>(result);

        return ServiceResult<CarriersConfigurationDto>.Success(dto);
    }

    public async Task<ServiceResult<CarriersConfigurationDto>> DeleteCarrierConfigurationAsync(int id)
    {
        var result = await _carrierConfigurationRepository.GetByIdAsync(id);

        if (result is null) return ServiceResult<CarriersConfigurationDto>.Fail("Kargo Firması bulunamadı");

        _carrierConfigurationRepository.Delete(result);
        await _unitOfWork.SaveChangeAsync();

        var dto = _mapper.Map<CarriersConfigurationDto>(result);

        return ServiceResult<CarriersConfigurationDto>.Success(dto);
    }
}