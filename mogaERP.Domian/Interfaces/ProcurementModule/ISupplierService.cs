using mogaERP.Domain.Contracts.ProcurementModule.Supplier;

namespace mogaERP.Domain.Interfaces.ProcurementModule;
public interface ISupplierService
{
    Task<ApiResponse<string>> CreateSupplierAsync(SupplierRequest request, CancellationToken cancellationToken = default);
    Task<ApiResponse<string>> DeleteSupplierAsync(int id, CancellationToken cancellationToken = default);
    Task<ApiResponse<PagedResponse<SupplierResponse>>> GetAllSuppliersAsync(SearchRequest searchRequest, CancellationToken cancellationToken = default);
    Task<ApiResponse<SupplierResponse>> GetSupplierByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<ApiResponse<string>> UpdateSupplierAsync(int id, SupplierRequest request, CancellationToken cancellationToken = default);
}
