using Cargo.Repository.Entities;
using Cargo.Service.Dto.CarrierConfiguration;

namespace Cargo.Service.Abstract;

public interface ICarrierConfigurationService
{
    Task<ServiceResult<List<CarriersConfigurationDto>>> GetAllCarrierConfigurationsAsync();
    Task<ServiceResult<CarriersConfigurationDto>> GetCarrierConfigurationByIdAsync(int id);
    Task<ServiceResult<CarriersConfigurationDto>> CreateCarrierConfigurationAsync(CreateCarrierConfigurationRequest request);
    Task<ServiceResult<CarriersConfigurationDto>> DeleteCarrierConfigurationAsync(int id);
    Task<ServiceResult<CarriersConfigurationDto>> UpdateCarrierConfigurationAsync(int id, CreateCarrierConfigurationRequest request);
}
