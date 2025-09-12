namespace mogaERP.Domain.Entities;
public class MainGroup : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<ItemGroup> ItemGroups { get; set; } = [];
}
