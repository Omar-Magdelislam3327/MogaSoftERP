using mogaERP.Domain.Contracts.ProcurementModule.PriceQuotation;

namespace mogaERP.Domain.Interfaces.ProcurementModule;
public interface IPriceQuotationService
{
    Task<ApiResponse<string>> CreatePriceQuotationAsync(PriceQuotationRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse<string>> DeletePriceQuotationAsync(int id, CancellationToken cancellationToken = default);
    Task<ApiResponse<PagedResponse<PriceQuotationResponse>>> GetAllPriceQuotationsAsync(SearchRequest searchRequest, CancellationToken cancellationToken = default);
    Task<ApiResponse<PriceQuotationResponse>> GetPriceQuotationByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ApiResponse<string>> UpdatePriceQuotationAsync(int id, PriceQuotationRequest request, CancellationToken cancellationToken = default);


    Task<ApiResponse<IReadOnlyList<PriceQuotationResponse>>> GetAllByPurchaseRequestIdAsync(int purchaseRequestId, CancellationToken cancellationToken = default);
    Task<ApiResponse<IReadOnlyList<PriceQuotationResponse>>> GetAllApprovedAsync(CancellationToken cancellationToken = default);
    Task<ApiResponse<string>> SubmitPriceQuotationByPurchaseRequestIdAsync(int purchaseRequestId, CancellationToken cancellationToken = default);
}
