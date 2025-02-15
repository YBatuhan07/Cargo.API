using Cargo.Service.Abstract;
using Cargo.Service.Dto.CarrierConfiguration;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarrierConfigurationController : CustomBaseController
{
    private readonly ICarrierConfigurationService _carrierConfigurationService;

    public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService)
    {
        _carrierConfigurationService = carrierConfigurationService;
    }

    [HttpGet]
    public async Task<IActionResult> GettAllCarrierConfiguration() => CreateActionResult(await _carrierConfigurationService.GetAllCarrierConfigurationsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarrierConfigurationById(int id) => CreateActionResult(await _carrierConfigurationService.GetCarrierConfigurationByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateCarrierConfiguration(CreateCarrierConfigurationRequest request) => CreateActionResult(await _carrierConfigurationService.CreateCarrierConfigurationAsync(request));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCarrierConfiguration(int id, CreateCarrierConfigurationRequest request) => CreateActionResult(await _carrierConfigurationService.UpdateCarrierConfigurationAsync(id, request));

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarrierConfiguration(int id) => CreateActionResult(await _carrierConfigurationService.DeleteCarrierConfigurationAsync(id));
}