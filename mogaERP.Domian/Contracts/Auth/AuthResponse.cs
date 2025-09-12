namespace mogaERP.Domain.Contracts.Auth;
public class AuthResponse
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }
    public int ExpiresIn { get; set; }
    public string FullName { get; set; }
}
