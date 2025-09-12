using mogaERP.Domain.Contracts.Common;

namespace mogaERP.Domain.Contracts.InventoryModule.Items;
public class ItemUnitRequest
{
    public string Name { get; set; }
}

public class ItemUnitResponse : AuditResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}

