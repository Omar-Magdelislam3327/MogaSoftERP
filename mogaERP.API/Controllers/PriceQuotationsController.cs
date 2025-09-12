using mogaERP.Domain.Contracts.ProcurementModule.PriceQuotation;
using mogaERP.Domain.Interfaces.ProcurementModule;

namespace mogaERP.API.Controllers;

public class PriceQuotationsController(IPriceQuotationService priceQuotationService) : BaseApiController
{
    private readonly IPriceQuotationService _priceQuotationService = priceQuotationService;

    [HttpPost]
    public async Task<IActionResult> CreatePriceQuotation([FromBody] PriceQuotationRequest request, CancellationToken cancellationToken)
    {
        var result = await _priceQuotationService.CreatePriceQuotationAsync(request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePriceQuotation(int id, CancellationToken cancellationToken)
    {
        var result = await _priceQuotationService.DeletePriceQuotationAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPriceQuotations([FromQuery] SearchRequest request, CancellationToken cancellationToken)
    {
        var result = await _priceQuotationService.GetAllPriceQuotationsAsync(request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPriceQuotationById(int id, CancellationToken cancellationToken)
    {
        var result = await _priceQuotationService.GetPriceQuotationByIdAsync(id, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePriceQuotation(int id, [FromBody] PriceQuotationRequest request, CancellationToken cancellationToken)
    {
        var result = await _priceQuotationService.UpdatePriceQuotationAsync(id, request, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("get-by-purchase-request/{purchaseRequestId}")]
    public async Task<IActionResult> GetPriceQuotationsByPurchaseRequestId(int purchaseRequestId, CancellationToken cancellationToken)
    {
        var result = await _priceQuotationService.GetAllByPurchaseRequestIdAsync(purchaseRequestId, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpPut("submit-price-quotation/{purchaseRequestId}")]
    public async Task<IActionResult> SubmitPriceQuotation(int purchaseRequestId, CancellationToken cancellationToken)
    {
        var result = await _priceQuotationService.SubmitPriceQuotationByPurchaseRequestIdAsync(purchaseRequestId, cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

    [HttpGet("approved")]
    public async Task<IActionResult> GetApprovedPriceQuotations(CancellationToken cancellationToken)
    {
        var result = await _priceQuotationService.GetAllApprovedAsync(cancellationToken);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
