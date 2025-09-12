using mogaERP.Domain.Contracts.Common;

namespace mogaERP.Domain.Contracts.InventoryModule.Items;
public class MainGroupRequest
{
    public string Name { get; set; }
}

public class MainGroupResponse : AuditResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}
