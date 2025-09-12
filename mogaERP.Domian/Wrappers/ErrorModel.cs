using mogaERP.Domain.Enums;
namespace mogaERP.Domain.Wrappers;
public record ErrorModel(string Message, AppStatusCode Status)
{
    public static readonly ErrorModel None = new(string.Empty, AppStatusCode.Success);
}
