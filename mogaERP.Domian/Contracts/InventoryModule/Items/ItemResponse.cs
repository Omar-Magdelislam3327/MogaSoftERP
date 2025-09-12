using mogaERP.Domain.Contracts.Common;

namespace mogaERP.Domain.Contracts.InventoryModule.Items;
public class ItemResponse : AuditResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal OrderLimit { get; set; }
    public decimal Cost { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal SalesTax { get; set; }
    public decimal Price { get; set; }
    public decimal PriceAfterTax { get; set; }
    public bool HasBarcode { get; set; }
    public bool IsGroupHead { get; set; }

    public int? UnitId { get; set; }
    public string? UnitName { get; set; }

    public int? GroupId { get; set; }
    public string? GroupName { get; set; }

    public int? MainGroupId { get; set; }
    public string? MainGroupName { get; set; }
}

public class ItemCreatedResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
