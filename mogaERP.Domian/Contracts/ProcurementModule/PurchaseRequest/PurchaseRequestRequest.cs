using mogaERP.Domain.Contracts.Common;
using mogaERP.Domain.Contracts.ProcurementModule.PriceQuotation;

namespace mogaERP.Domain.Contracts.ProcurementModule.PurchaseRequest;
public class PurchaseRequestRequest
{
    public DateOnly RequestDate { get; set; }
    public DateOnly? DueDate { get; set; }
    public string Purpose { get; set; }
    public string? Notes { get; set; }

    public int StoreId { get; set; }
    public List<PurchaseRequestItemRequest> Items { get; set; } = [];
}

public class PurchaseRequestResponse : AuditResponse
{
    public int Id { get; set; }
    public string RequestNumber { get; set; }
    public DateOnly RequestDate { get; set; }
    public DateOnly? DueDate { get; set; }
    public string Purpose { get; set; }
    public int StoreId { get; set; }
    public string StoreName { get; set; }
    public string Status { get; set; }
    public string? Notes { get; set; }


    public List<PurchaseRequestItemResponse> Items { get; set; } = [];
    public PriceQuotationResponse? PriceQuotation { get; set; }
}
