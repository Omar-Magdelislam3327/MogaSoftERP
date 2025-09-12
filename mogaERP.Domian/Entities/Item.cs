namespace mogaERP.Domain.Entities;
public class Item : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal OrderLimit { get; set; }
    public decimal Cost { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal SalesTax { get; set; }
    public decimal Price { get; set; }
    public decimal PriceAfterTax => Price + (Price * SalesTax / 100);
    public bool HasBarcode { get; set; }
    public bool IsGroupHead { get; set; }

    public int? UnitId { get; set; }
    public int? GroupId { get; set; }
    public ItemGroup? Group { get; set; } = default!;
    public ItemUnit? Unit { get; set; } = default!;
}