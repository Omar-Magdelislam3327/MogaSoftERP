namespace mogaERP.Domain.Contracts.Common;
public class AuditResponse
{
    public string CreatedById { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }


    public string? UpdatedById { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
