using mogaERP.Domain.Contracts.Common;

namespace mogaERP.Domain.Contracts.InventoryModule.Items;
public class ItemGroupRequest
{
    public string Name { get; set; }
    public int? MainGroupId { get; set; }
}

public class ItemGroupResponse : AuditResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? MainGroupId { get; set; }
    public string? MainGroupName { get; set; }
}
