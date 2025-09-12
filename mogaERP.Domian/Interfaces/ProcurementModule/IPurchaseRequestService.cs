using mogaERP.Domain.Contracts.ProcurementModule.PurchaseRequest;

namespace mogaERP.Domain.Interfaces.ProcurementModule;
public interface IPurchaseRequestService
{
    Task<ApiResponse<string>> CreatePurchaseRequestAsync(PurchaseRequestRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse<string>> DeletePurchaseRequestAsync(int id, CancellationToken cancellationToken = default);
    Task<ApiResponse<string>> UpdatePurchaseRequestAsync(int id, PurchaseRequestRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse<PurchaseRequestResponse>> GetPurchaseRequestByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ApiResponse<PagedResponse<PurchaseRequestResponse>>> GetAllPurchaseRequestsAsync(SearchRequest search, CancellationToken cancellationToken = default);

    Task<ApiResponse<string>> ApprovePurchaseRequestAsync(int id, CancellationToken cancellationToken = default);
    Task<ApiResponse<IReadOnlyList<PurchaseRequestResponse>>> GetAllApprovedAsync(CancellationToken cancellationToken = default);
}
