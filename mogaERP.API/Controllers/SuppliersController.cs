using mogaERP.Domain.Contracts.ProcurementModule.Supplier;
using mogaERP.Domain.Interfaces.ProcurementModule;

namespace mogaERP.API.Controllers;

public class SuppliersController(ISupplierService supplierService) : BaseApiController
{
    private readonly ISupplierService _supplierService = supplierService;

    [HttpPost]
    public async Task<IActionResult> CreateSupplier([FromBody] SupplierRequest request, CancellationToken cancellationToken)
    {
        var result = await _supplierService.CreateSupplierAsync(request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSupplier(int id, CancellationToken cancellationToken)
    {
        var result = await _supplierService.DeleteSupplierAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSuppliers([FromQuery] SearchRequest request, CancellationToken cancellationToken)
    {
        var result = await _supplierService.GetAllSuppliersAsync(request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplierById(int id, CancellationToken cancellationToken)
    {
        var result = await _supplierService.GetSupplierByIdAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierRequest request, CancellationToken cancellationToken)
    {
        var result = await _supplierService.UpdateSupplierAsync(id, request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
