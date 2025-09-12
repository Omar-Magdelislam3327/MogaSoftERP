using mogaERP.Domain.Enums;

namespace mogaERP.Domain.Entities;
public class PurchaseRequest : BaseEntity
{
    public string RequestNumber { get; set; } = string.Empty;
    public DateOnly RequestDate { get; set; }
    public DateOnly? DueDate { get; set; }
    public string Purpose { get; set; } = string.Empty;
    public PurchaseStatus Status { get; set; } = PurchaseStatus.Pending;
    public string? Notes { get; set; }

    public int StoreId { get; set; }
    public Store Store { get; set; } = default!;
    public ICollection<PurchaseRequestItem> Items { get; set; } = new HashSet<PurchaseRequestItem>();

    // request can have many quotations
    public ICollection<PriceQuotation> PriceQuotations { get; set; } = new HashSet<PriceQuotation>();

    // only set when a quotation is awarded
    public int? AwardedQuotationId { get; set; }
    public PriceQuotation? AwardedQuotation { get; set; }
}
