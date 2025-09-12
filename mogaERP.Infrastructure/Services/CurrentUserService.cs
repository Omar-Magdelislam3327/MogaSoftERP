using Microsoft.AspNetCore.Http;
using mogaERP.Domain.Extensions;
using mogaERP.Domain.Interfaces.Common;

namespace mogaERP.Infrastructure.Services;
public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string? UserId =>
        _httpContextAccessor.HttpContext?.User?.GetUserId();
}
