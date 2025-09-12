using mogaERP.Domain.Enums;

namespace mogaERP.Domain.Entities;
public class PriceQuotation : BaseEntity
{
    public string QuotationNumber { get; set; } = string.Empty;
    public DateOnly QuotationDate { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;
    public string? Notes { get; set; }
    public QuotationStatus Status { get; set; } = QuotationStatus.Pending;

    // FK for PurchaseRequest
    public int PurchaseRequestId { get; set; }
    public PurchaseRequest PurchaseRequest { get; set; } = default!;

    public ICollection<PriceQuotationItem> Items { get; set; } = new HashSet<PriceQuotationItem>();
}
