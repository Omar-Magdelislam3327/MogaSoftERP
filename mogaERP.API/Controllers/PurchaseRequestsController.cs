using mogaERP.Domain.Contracts.ProcurementModule.PurchaseRequest;
using mogaERP.Domain.Interfaces.ProcurementModule;


namespace mogaERP.API.Controllers;

public class PurchaseRequestsController(IPurchaseRequestService purchaseRequestService) : BaseApiController
{
    private readonly IPurchaseRequestService _purchaseRequestService = purchaseRequestService;

    [HttpPost]
    public async Task<IActionResult> CreatePurchaseRequest([FromBody] PurchaseRequestRequest request, CancellationToken cancellationToken)
    {
        var result = await _purchaseRequestService.CreatePurchaseRequestAsync(request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPurchaseRequests([FromQuery] SearchRequest request, CancellationToken cancellationToken)
    {
        var result = await _purchaseRequestService.GetAllPurchaseRequestsAsync(request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPurchaseRequestById(int id, CancellationToken cancellationToken)
    {
        var result = await _purchaseRequestService.GetPurchaseRequestByIdAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePurchaseRequest(int id, [FromBody] PurchaseRequestRequest request, CancellationToken cancellationToken)
    {
        var result = await _purchaseRequestService.UpdatePurchaseRequestAsync(id, request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePurchaseRequest(int id, CancellationToken cancellationToken)
    {
        var result = await _purchaseRequestService.DeletePurchaseRequestAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result) : NotFound(result);
    }

    [HttpPut("{id}/approve")]
    public async Task<IActionResult> ApprovePurchaseRequest(int id, CancellationToken cancellationToken)
    {
        var result = await _purchaseRequestService.ApprovePurchaseRequestAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("approved")]
    public async Task<IActionResult> GetApprovedPurchaseRequests(CancellationToken cancellationToken)
    {
        var result = await _purchaseRequestService.GetAllApprovedAsync(cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
