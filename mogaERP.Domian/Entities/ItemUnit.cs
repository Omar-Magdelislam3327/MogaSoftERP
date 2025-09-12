namespace mogaERP.Domain.Entities;
public class ItemUnit : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<Item> Items { get; set; } = [];
}
