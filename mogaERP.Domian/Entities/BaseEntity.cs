namespace mogaERP.Domain.Entities;
public class BaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; } = false;


    public string CreatedById { get; set; } = string.Empty;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedOn { get; set; }
    public string? UpdatedById { get; set; }

    public ApplicationUser CreatedBy { get; set; } = default!;
    public ApplicationUser? UpdatedBy { get; set; }
}
