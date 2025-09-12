namespace mogaERP.Domain.Entities;
public class ItemGroup : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public int? MainGroupId { get; set; }
    public MainGroup? MainGroup { get; set; } = default!;
    public ICollection<Item> Items { get; set; } = [];
}
