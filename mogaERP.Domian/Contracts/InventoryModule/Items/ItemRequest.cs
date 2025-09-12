namespace mogaERP.Domain.Contracts.InventoryModule.Items;
public class ItemRequest
{
    public string Name { get; set; }
    public decimal OrderLimit { get; set; }
    public decimal Cost { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal SalesTax { get; set; }
    public decimal Price { get; set; }
    public bool HasBarcode { get; set; }

    public int UnitId { get; set; }
    public int GroupId { get; set; }
}
