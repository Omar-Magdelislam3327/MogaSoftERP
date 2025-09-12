using mogaERP.Domain.Contracts.Auth;
using mogaERP.Domain.Wrappers;

namespace mogaERP.Domain.Interfaces.Auth;
public interface IAuthService
{
    Task<ApiResponse<AuthResponse>> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken);
    Task<ApiResponse<string>> RegisterAsync(RegisterUserRequest request, CancellationToken cancellationToken);

}
