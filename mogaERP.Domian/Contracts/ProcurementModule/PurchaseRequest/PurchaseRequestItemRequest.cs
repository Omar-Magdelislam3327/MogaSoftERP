namespace mogaERP.Domain.Contracts.ProcurementModule.PurchaseRequest;
public class PurchaseRequestItemRequest
{
    public int ItemId { get; set; }
    public decimal Quantity { get; set; }
    public string? Notes { get; set; }
}

public class PurchaseRequestItemResponse
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public decimal Quantity { get; set; }
    public string? Notes { get; set; }
}

